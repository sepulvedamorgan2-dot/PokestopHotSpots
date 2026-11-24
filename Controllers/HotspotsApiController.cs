using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Data;
using PokestopHotSpots.Models;

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
}