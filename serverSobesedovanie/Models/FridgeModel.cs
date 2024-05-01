using System.ComponentModel.DataAnnotations;

namespace serverSobesedovanie.Models
{
    public class FridgeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Year { get; set; }
        public Fridge Fridge { get; set; }
    }
}
