using System.ComponentModel.DataAnnotations;

namespace BlogPlatformAPI.DTOs.Auth;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
} 