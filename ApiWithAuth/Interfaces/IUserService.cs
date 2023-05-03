using ApiWithAuth.DTOs;
using ApiWithAuth.Entity;

namespace ApiWithAuth.Interfaces;

public interface IUserService
{
    Task<AuthResponse> LoginAsync(AuthRequest request);
    Task<string> PasswordUpdateAsync(RefreshRequest request);
    Task RenameUserAsync(RenameRequest request);
    Task ForgotPasswordAsync(string email);
    Task<List<AppUser>> GetAllUsers();
    Task<AppUser?> GetUserByEmail(string email);
}