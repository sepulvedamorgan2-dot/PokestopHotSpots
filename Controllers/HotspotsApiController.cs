using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Data;
using PokestopHotSpots.Models;
using PokestopHotSpots.Dtos;
namespace PokestopHotSpots.Controllers;


[ApiController]
[Route("api/hotspots")]
public class HotspotsApiController : ControllerBase
{
    private readonly PokestopHotspotContext _context;

    public HotspotsApiController(PokestopHotspotContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<List<Hotspot>> GetAll()
    {
        return await _context.Hotspots.ToListAsync();
    }
    

[HttpGet("{id:int}")]
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


}