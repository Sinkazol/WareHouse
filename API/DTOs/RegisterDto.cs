using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        public required string Email { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Password { get; set; }

    }
}
