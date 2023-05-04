using System.ComponentModel.DataAnnotations;

namespace ApiWithAuth.DTOs;

    public class RegistrationRequest
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required] 
        public string FirstName { get; set; } = null!;
        
        [Required] 
        public string LastName { get; set; } = null!;
        
        [Required] 
        public string Patronymic { get; set; } = null!;
    }
