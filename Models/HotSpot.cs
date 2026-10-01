using System.ComponentModel.DataAnnotations;
namespace PokestopHotSpots.Models;

public class Hotspot
{
    public int Id { get; set; }
    
    
    [Required]
    [StringLength(40, MinimumLength = 3)]
    [Display(Name = "Hotspot Name")]
    public string Name { get; set; } = "";

    
    [Range(0, 20)]
    [Display(Name = "Number of Nearby Gyms")]
    public int GymCount { get; set; }


    [Required]
    [Display(Name = "Pokestop Density")]
    public string PokestopDensity { get; set; } = "";


    [Display(Name = "Parking Availability?")]
    public bool hasParking { get; set; }
    
}