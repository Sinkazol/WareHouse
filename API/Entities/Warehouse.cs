using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace API.Entities
{
    public class Warehouse
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public required string Address { get; set; }


        // Navigációs property
        [JsonIgnore]
        [XmlIgnoreAttribute]
        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        [JsonIgnore]
        [XmlIgnoreAttribute]
        public virtual ICollection<Logistic> SourceLogistics { get; set; } = new List<Logistic>();
        [JsonIgnore]
        [XmlIgnoreAttribute]
        public virtual ICollection<Logistic> DestinationLogistics { get; set; } = new List<Logistic>();
    }
}
