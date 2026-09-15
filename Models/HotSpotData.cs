namespace PokestopHotSpots.Models;

public static class HotSpotData
{
    public static List<Hotspot> All { get; } = new()
    {
        new Hotspot { Id = 1, Name = "Lakefront Park", GymCount = 6, PokestopDensity = "High", hasParking = true },
        new Hotspot { Id = 2, Name = "Veterans Park", GymCount = 4, PokestopDensity = "High", hasParking = true },
        new Hotspot { Id = 3, Name = "Milwaukee Public Market", GymCount = 3, PokestopDensity = "High", hasParking = false },
        new Hotspot { Id = 4, Name = "Historic Third Ward", GymCount = 4, PokestopDensity = "High", hasParking = false },
        new Hotspot { Id = 5, Name = "Bradford Beach", GymCount = 3, PokestopDensity = "Medium", hasParking = true },
        new Hotspot { Id = 6, Name = "Washington Park", GymCount = 4, PokestopDensity = "Medium", hasParking = true },
        new Hotspot { Id = 7, Name = "Mitchell Park Domes", GymCount = 3, PokestopDensity = "Medium", hasParking = true },
        new Hotspot { Id = 8, Name = "Humboldt Park", GymCount = 2, PokestopDensity = "Medium", hasParking = true },
        new Hotspot { Id = 9, Name = "Bay View Park", GymCount = 2, PokestopDensity = "Low", hasParking = true },
        new Hotspot { Id = 10, Name = "Kletzsch Park", GymCount = 2, PokestopDensity = "Low", hasParking = true }
    };
}