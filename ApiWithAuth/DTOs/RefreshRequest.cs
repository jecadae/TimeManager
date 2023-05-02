using System.ComponentModel.DataAnnotations;

namespace ApiWithAuth;

public class RefreshRequest
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string NewPassword { get; set; } = null!;
}