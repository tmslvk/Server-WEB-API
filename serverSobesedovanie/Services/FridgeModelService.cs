using Microsoft.EntityFrameworkCore;
using serverSobesedovanie.DTO;
using serverSobesedovanie.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace serverSobesedovanie.Services
{
    public class FridgeModelService
    {
        ApplicationContext db;

        public FridgeModelService(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<FridgeModel> Add(FridgeModelDTO fridgeModelDTO)
        {
            var fridgeModel = new FridgeModel()
            {
                Name = fridgeModelDTO.Name,
                Year = fridgeModelDTO.Year,
            };

            await db.FridgeModels.AddAsync(fridgeModel);
            await db.SaveChangesAsync();

            return fridgeModel;
        }

        public async Task<FridgeModel> Get(int id)
        {
            return await db.FridgeModels.FirstOrDefaultAsync(fm => fm.Id == id);
        }

        public async Task Delete(int id)
        {
            var model = await Get(id);

            db.FridgeModels.Remove(model);
            await db.SaveChangesAsync();
        }

        public async Task<List<FridgeModel>> GetAll()
        {
            return await db.FridgeModels.ToListAsync();
        }

    }
}
