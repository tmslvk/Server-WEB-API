using serverSobesedovanie.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace serverSobesedovanie.DTO
{
    public class FridgeProductDTO
    {
        public int ProductId { get; set; }
        public int FridgeId { get; set; }
        public int Quantity { get; set; }
        public Fridge Fridge { get; set; }
        public Product Product { get; set; }
    }
}
