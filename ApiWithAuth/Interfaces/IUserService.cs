using ApiWithAuth.DTOs;
using ApiWithAuth.Domain.Models;

namespace ApiWithAuth.Interfaces;

public interface IUserService
{
    Task<AuthResponse> LoginAsync(AuthRequest request);
    Task<string> PasswordUpdateAsync(RefreshRequest request);
    Task RenameUserAsync(RenameRequest request);
    Task ForgotPasswordAsync(string email);
    Task<List<AppUser>> GetAllUsers();
    Task<AppUser?> GetUserByEmail(string email);
    Task ResetPasswordAsync(string email, string resetToken, string newPassword);
}