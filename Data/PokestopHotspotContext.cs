using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Models;

namespace PokestopHotSpots.Data;


public class PokestopHotspotContext : DbContext
{
    public PokestopHotspotContext(DbContextOptions<PokestopHotspotContext> options) : base(options)
    {
    }

    public DbSet<Hotspot> Hotspots => Set<Hotspot>(); 
    public DbSet<HotspotRegular> HotspotRegulars => Set<HotspotRegular>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Hotspot>().HasData(
        new Hotspot { Id = 1, Name = "Lakefront Park", GymCount = 6, PokestopDensity = "High", hasParking = true, Description = "A beautiful park along the lakefront with plenty of Pokestops and gyms." },
        new Hotspot { Id = 2, Name = "Veterans Park", GymCount = 4, PokestopDensity = "High", hasParking = true, Description = "A popular park with a high density of Pokestops and gyms, perfect for Pokemon Go players." },
        new Hotspot { Id = 3, Name = "Milwaukee Public Market", GymCount = 3, PokestopDensity = "High", hasParking = false, Description = "A vibrant market with a variety of shops and eateries." },
        new Hotspot { Id = 4, Name = "Historic Third Ward", GymCount = 4, PokestopDensity = "High", hasParking = false, Description = "A historic neighborhood with a rich cultural heritage." },
        new Hotspot { Id = 5, Name = "Bradford Beach", GymCount = 3, PokestopDensity = "Medium", hasParking = true, Description = "A lovely beach with a great view and plenty of space to play." },
        new Hotspot { Id = 6, Name = "Washington Park", GymCount = 4, PokestopDensity = "Medium", hasParking = true, Description = "A large park with a variety of recreational activities and a moderate density of Pokestops and gyms." },
        new Hotspot { Id = 7, Name = "Mitchell Park Domes", GymCount = 3, PokestopDensity = "Medium", hasParking = true, Description = "A beautiful conservatory with a variety of plants and flowers." },
        new Hotspot { Id = 8, Name = "Humboldt Park", GymCount = 2, PokestopDensity = "Medium", hasParking = true, Description = "A peaceful park with a variety of trees and green spaces." },
        new Hotspot { Id = 9, Name = "Bay View Park", GymCount = 2, PokestopDensity = "Low", hasParking = true, Description = "A quiet park with a peaceful atmosphere and a low density of Pokestops and gyms." },
        new Hotspot { Id = 10, Name = "Kletzsch Park", GymCount = 2, PokestopDensity = "Low", hasParking = true, Description = "A small park with a peaceful atmosphere and a low density of Pokestops and gyms." }
    );
    
}

}