using ApiWithAuth.DTOs;

namespace ApiWithAuth.Interfaces;

public interface IUserService
{
    Task<AuthResponse> loginAsync(AuthRequest request);
    Task<string> PasswordUpdateAsync(RefreshRequest request);
    Task RenameUserAsync(RenameRequest request);
    Task ForgotPasswordAsync(string email);
}