using System.ComponentModel.DataAnnotations;

namespace PokestopHotSpots.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password), ErrorMessage = "The two passwords don't match.")]
    public string ConfirmPassword { get; set; } = "";
    
    [StringLength(15, MinimumLength = 4)]
    public string TrainerName { get; set; } = "";

    [Required(ErrorMessage = "Friendship Codes are 12 digits long.")]
    [StringLength(12, MinimumLength = 12)]
    [Display(Name = "Friendship Code")]
    public string FriendshipCode { get; set; } = "";
}