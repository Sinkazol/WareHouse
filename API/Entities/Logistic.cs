using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Logistic
    {
        [Required]
        public string SourceId { get; set; }

        [ForeignKey("SourceId")]
        public Warehouse Source { get; set; }  // Kapcsolat a Warehouse entitással
        [Required]
        public string DestinationId { get; set; }

        [ForeignKey("DestinationId")]
        public Warehouse Destination { get; set; }  // Kapcsolat a Warehouse entitással
        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }  // Kapcsolat a Product entitással
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public int Quantity { get; set; }


    }
}
