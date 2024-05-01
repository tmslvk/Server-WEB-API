using serverSobesedovanie.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace serverSobesedovanie.DTO
{
    public class FridgeDTO
    {
        public string Name { get; set; }
        public string? OwnerName { get; set; }
        public int ModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }
        public List<FridgeProduct> FridgeProducts { get; set; }
    }
}
