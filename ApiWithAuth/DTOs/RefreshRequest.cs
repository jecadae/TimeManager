using System.ComponentModel.DataAnnotations;

namespace ApiWithAuth.DTOs;

public class RefreshRequest
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string NewPassword { get; set; } = null!;
}