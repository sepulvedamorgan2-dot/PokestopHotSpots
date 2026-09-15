namespace PokestopHotSpots.Models;

public class HotSpot
{
    public int HotSpotID { get; set; }
    public string Name { get; set; }
    public int GymCount { get; set; }
    public string PokestopDensity { get; set; }
    public bool hasParking { get; set; }
}