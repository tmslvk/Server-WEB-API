using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace serverSobesedovanie.Models
{
    public class Fridge
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? OwnerName { get; set; }

        [ForeignKey("ModelId")]
        public int ModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }
        public List<FridgeProduct> FridgeProducts { get; set; }
    }
}
