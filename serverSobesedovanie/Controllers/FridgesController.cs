using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using serverSobesedovanie.DTO;
using serverSobesedovanie.Models;
using serverSobesedovanie.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace serverSobesedovanie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        IConfiguration _configuration;
        FridgeService fridgesService;
        ApplicationContext db;
        public FridgesController(IConfiguration configuration, FridgeService service)
        {
            this._configuration = configuration;
            this.fridgesService = service;
        }

        [HttpPost]
        public async Task<ActionResult<Fridge>> Add(FridgeDTO fridgeDTO)
        {
            var fridge = await fridgesService.Add(fridgeDTO);
            return Created("", fridge);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Fridge>> Delete(int id)
        {
            await fridgesService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<List<FridgeProduct>>> GetFridgeProducts(int id)
        {
            var fridgeProducts = await fridgesService.GetProducts(id);

            return Ok(fridgeProducts);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Fridge>> Update(int id, FridgeDTO fridgeDTO)
        {
            var fridge = await fridgesService.Update(id, fridgeDTO);
            if (fridge == null)
            {
                return NoContent();
            }
            return Ok(fridge);
        }
    }
}
