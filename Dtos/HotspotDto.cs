namespace PokestopHotSpots.Dtos;

// One line of a truck's menu, as the API says it. The dish's name instead of
// a Dish object, and no way back to the truck.
public class HotspotDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int GymCount { get; set; }
    public string PokestopDensity { get; set; } = "";
    public bool hasParking { get; set; }
    public string? Description { get; set; }
    public List<HotspotRegularDto> HotspotRegulars { get; set; } = new List<HotspotRegularDto>();
    
}