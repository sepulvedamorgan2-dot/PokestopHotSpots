namespace PokestopHotSpots.Models;

public static class HotSpotData
{
    public static List<HotSpot> All { get; } = new()
    {
        new HotSpot { HotSpotID = 1, Name = "Central Park", GymCount = 5, PokestopDensity = "High", hasParking = true },
        new HotSpot { HotSpotID = 2, Name = "Downtown Plaza", GymCount = 3, PokestopDensity = "Medium", hasParking = false },
        new HotSpot { HotSpotID = 3, Name = "Riverside Park", GymCount = 2, PokestopDensity = "Low", hasParking = true },
        new HotSpot { HotSpotID = 4, Name = "Honey Creek Park", GymCount = 3, PokestopDensity = "High", hasParking = true },
    };
}