using serverSobesedovanie.Models;

namespace serverSobesedovanie.DTO
{
    public class FridgeModelDTO
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public Fridge Fridge { get; set; }
    }
}
