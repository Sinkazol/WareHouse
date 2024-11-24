using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace API.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public required string RoleName { get; set; }

        [JsonIgnore]
        [XmlIgnoreAttribute]
        public virtual ICollection<AppUser> Users { get; set; } // Navigációs property
    }
}
