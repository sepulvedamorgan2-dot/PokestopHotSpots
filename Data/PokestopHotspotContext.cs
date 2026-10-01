using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Models;

namespace PokestopHotSpots.Data;


public class PokestopHotspotContext : DbContext
{
    public PokestopHotspotContext(DbContextOptions<PokestopHotspotContext> options) : base(options)
    {
    }

    public DbSet<Hotspot> Hotspots => Set<Hotspot>(); 
}