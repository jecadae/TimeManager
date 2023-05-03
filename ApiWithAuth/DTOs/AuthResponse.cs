using ApiWithAuth.Entity;

namespace ApiWithAuth;

    public class AuthResponse
    {
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }