namespace ApiWithAuth.DTOs;

public class RenameRequest
{
    public string Email { get; set; } = null!;
    public string FirstName{ get; set; } = null!;
    public string LastName{ get; set; } = null!;
    public string Patronymic{ get; set; } = null!;
}