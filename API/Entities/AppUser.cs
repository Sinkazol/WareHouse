using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class AppUser
    {
        [Key]
        public required string Email { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        
        [Required]
        public required int RoleId { get; set; }

        // Navigációs property
        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
    }
}
