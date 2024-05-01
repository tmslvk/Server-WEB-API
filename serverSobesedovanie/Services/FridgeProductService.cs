using Microsoft.EntityFrameworkCore;
using serverSobesedovanie.DTO;
using serverSobesedovanie.Models;
using System.Linq;
using System.Threading.Tasks;

namespace serverSobesedovanie.Services
{
    public class FridgeProductService
    {
        ApplicationContext db;

        public FridgeProductService(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<FridgeProduct> Get(int id)
        {
            return await db.FridgeProducts.FirstOrDefaultAsync(fp => fp.Id == id);
        }

        public async Task<FridgeProduct> Add(FridgeProductDTO fridgeProductDTO)
        {
            FridgeProduct fridgeProduct = new FridgeProduct()
            {
                Quantity = fridgeProductDTO.Quantity,
                Product = fridgeProductDTO.Product,
                Fridge = fridgeProductDTO.Fridge
            };

            await db.FridgeProducts.AddAsync(fridgeProduct);
            await db.SaveChangesAsync();

            return fridgeProduct;
        }

        public async Task Delete(int id)
        {
            var fridgeProduct = await Get(id);

            db.FridgeProducts.Remove(fridgeProduct);
            await db.SaveChangesAsync();
        }

       
    }
}
