using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = string.Empty;
    [Required] public string? KnownAs { get; set; }
    [Required] public string? Gender { get; set; }
    [Required] public string? DateOfBirth { get; set; }
    [Required] public string? City { get; set; }
    [Required] public string? Country { get; set; }
    [Required]
    [StringLength(6, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

}
