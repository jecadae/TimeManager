using ApiWithAuth.Entity;

namespace ApiWithAuth;

    public class AuthResponse
    {
        public long id { get; set; }
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public AppPlan[]? AppPlans{ get; set; }
    }
