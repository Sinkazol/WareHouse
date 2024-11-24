using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Stock
    {
        [Required]
        public required string WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public Warehouse? Warehouse { get; set; }  // Navigációs tulajdonság
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public  Product? Product { get; set; }  // Navigációs tulajdonság

        [Required]
        public int Quantity { get; set; }

    }
}
