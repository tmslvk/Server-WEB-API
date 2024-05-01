using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace serverSobesedovanie.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        public List<FridgeProduct> FridgeProducts { get; set; }
    }
}
