using System.ComponentModel.DataAnnotations;

namespace AuthorizationFilterSystemImplementation.DTOs;

public class LoginDTO
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Display(Name = "Email")]
    public string Email { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must have at least 6 characters")]
    public string Password { get; set; }
}