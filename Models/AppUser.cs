using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace PokestopHotSpots.Models;

public class AppUser : IdentityUser
{
    // What the navbar calls you. A new column on AspNetUsers.
    [StringLength(15, MinimumLength = 4)]
    [Display(Name = "Trainer Name")]
    public string TrainerName { get; set; } = "";

    [Required(ErrorMessage = "Friendship Codes are 12 digits long.")]
    [StringLength(12, MinimumLength = 12)]
    [Display(Name = "Friendship Code")]
    public string FriendshipCode { get; set; } = "";

}