using serverSobesedovanie.Models;
using System.Collections.Generic;

namespace serverSobesedovanie.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        public List<FridgeProduct> FridgeProducts { get; set; }
    }
}
