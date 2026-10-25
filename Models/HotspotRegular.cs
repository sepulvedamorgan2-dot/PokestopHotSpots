using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace PokestopHotSpots.Models;

public class HotspotRegular
{
    public int Id { get; set; }

    [Required(ErrorMessage = "What is your in game name?")]
    [StringLength(60, MinimumLength = 2)]
    public string Name { get; set; } = "";

  
    [Required(ErrorMessage = "Friendship Codes are 12 digits long.")]
    [StringLength(12, MinimumLength = 12)]
    public string FriendshipCode { get; set; } = "";

    [Display(Name = "Looking for Daily Gift Friend?")]
    public bool SendsDailyGifts { get; set; } = false;
    

    // The foreign key. THIS is the column that exists in the table.
    [Display(Name = "Hotspot")]
    public int HotspotId { get; set; }

    // The navigation property. Not a column. EF fills it in when asked.
    public Hotspot? Hotspot { get; set; }
}