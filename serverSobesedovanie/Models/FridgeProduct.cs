using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serverSobesedovanie.Models
{
    public class FridgeProduct
    {
        public int Id { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [ForeignKey("FridgeId")]
        public int FridgeId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Fridge Fridge { get; set; }
        public Product Product { get; set; }
    }
}
