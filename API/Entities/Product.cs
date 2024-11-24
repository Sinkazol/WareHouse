using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace API.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Price {  get; set; }

        // Navigációs property
        [JsonIgnore]
        [XmlIgnoreAttribute]
        public virtual ICollection<Logistic>? Logistics { get; set; } = new List<Logistic>();

        [JsonIgnore]
        [XmlIgnoreAttribute]
        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    }
}
