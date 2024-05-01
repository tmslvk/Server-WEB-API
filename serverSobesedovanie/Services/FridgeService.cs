using Microsoft.EntityFrameworkCore;
using serverSobesedovanie.DTO;
using serverSobesedovanie.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serverSobesedovanie.Services
{
    public class FridgeService
    {
        ApplicationContext db;

        public FridgeService(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<Fridge> Add(FridgeDTO fridgeDTO)
        {
            Fridge fridge = new Fridge()
            {
                OwnerName = fridgeDTO.OwnerName,
                FridgeModel = fridgeDTO.FridgeModel,
                Name = fridgeDTO.Name,
                FridgeProducts = fridgeDTO.FridgeProducts
            };
            await db.Fridges.AddAsync(fridge);
            await db.SaveChangesAsync();

            return fridge;
        }

        public async Task<Fridge> Get(int id)
        {
            return await db.Fridges.FirstOrDefaultAsync(f=>f.Id == id);
        }

        public async Task<List<Product>> GetProducts(int id)
        {
            var fridge = await Get(id);

            return fridge.FridgeProducts.Select(fp=>fp.Product).ToList();
        }

        public async Task Delete(int id)
        {
            var fridge = await Get(id);

            db.Fridges.Remove(fridge);
            await db.SaveChangesAsync();
        }

        public async Task<Fridge> Update(int id, FridgeDTO fridgeDTO)
        {
            var fridge = await Get(id);

            if(fridge.Name != null)
            {
                fridge.Name = fridgeDTO.Name;
            }
            if (fridge.OwnerName != null)
            {
                fridge.OwnerName = fridgeDTO.OwnerName;
            }
            return fridge;
        }
    }
}
