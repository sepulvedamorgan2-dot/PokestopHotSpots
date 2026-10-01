using Microsoft.EntityFrameworkCore;
using Hotspot.Models;

namespace PokestopHotSpots.Data;


public class PokestopHotspotContext : DbContext
{
    public PokestopHotspotContext(DbContextOptions<PokestopHotspotContext> options)
        : base(options)
    {
    }

    public DbSet<Hotspot> Hotspots => Set<Hotspot>(); ;
}