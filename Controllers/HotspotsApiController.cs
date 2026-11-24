using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Data;
using PokestopHotSpots.Models;
using PokestopHotSpots.Dtos;
using Microsoft.AspNetCore.Authorization;
namespace PokestopHotSpots.Controllers;


[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/hotspots")]
public class HotspotsApiController : ControllerBase
{
    private readonly PokestopHotspotContext _context;

    public HotspotsApiController(PokestopHotspotContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    [AllowAnonymous]
    public async Task<List<Hotspot>> GetAll()
    {
        return await _context.Hotspots.ToListAsync();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, HotspotInputDto input)
    {
        var hotspot = await _context.Hotspots.FindAsync(id);
        if (hotspot == null)
        {
            return NotFound();
        }

        hotspot.Name = input.Name;
        hotspot.GymCount = input.GymCount;
        hotspot.PokestopDensity = input.PokestopDensity;
        hotspot.hasParking = input.hasParking;
        hotspot.Description = input.Description;


        await _context.SaveChangesAsync();
        return NoContent();
    }


     [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var hotspot = await _context.Hotspots.FindAsync(id);
        if (hotspot == null)
        {
            return NotFound();
        }

        _context.Hotspots.Remove(hotspot);
        await _context.SaveChangesAsync();
        return NoContent();
    }

[HttpGet("{id:int}")]
[AllowAnonymous]
public async Task<ActionResult<Hotspot>> GetOne(int id)
{
    var hotspot = await _context.Hotspots
        .Include(h => h.HotspotRegulars)
        .FirstOrDefaultAsync(h => h.Id == id);

    if (hotspot == null)
    {
        return NotFound();
    }

    return Ok(ToDto(hotspot));
}
private static HotspotDto ToDto(Hotspot hotspot) => new HotspotDto
{
    Id  = hotspot.Id,
    Name = hotspot.Name,
    GymCount = hotspot.GymCount,
    PokestopDensity = hotspot.PokestopDensity,
    hasParking = hotspot.hasParking,
    Description = hotspot.Description,
    HotspotRegulars = hotspot.HotspotRegulars.Select(hr => new HotspotRegularDto
    {
        Name = hr.Name,
        FriendshipCode = hr.FriendshipCode,
        SendsDailyGifts = hr.SendsDailyGifts
    }).ToList(),
};
[HttpPost]
public async Task<ActionResult<HotspotDto>> Create(HotspotInputDto input)
{
    var hotspot = new Hotspot
    {
        Name = input.Name,
        GymCount = input.GymCount,
        PokestopDensity = input.PokestopDensity,
        hasParking = input.hasParking,
        Description = input.Description
    };



    _context.Hotspots.Add(hotspot);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetOne), new { id = hotspot.Id }, ToDto(hotspot));
}


}