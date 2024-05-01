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
    public class FridgeModelController : ControllerBase
    {
        IConfiguration _configuration;
        FridgeModelService fridgeModelService;
        ApplicationContext db;

        public FridgeModelController(IConfiguration configuration, FridgeModelService service)
        {
            this._configuration = configuration;
            this.fridgeModelService = service;
        }

        [HttpPost]
        public async Task<ActionResult<FridgeModel>> Add(FridgeModelDTO fridgeModelDTO) 
        {
            var fridgeModel = await fridgeModelService.Add(fridgeModelDTO);
            return Created(" ", fridgeModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FridgeModel>> Delete(int id)
        {
            await fridgeModelService.Delete(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<FridgeModel>>> GetAll()
        {
            var list = await fridgeModelService.GetAll();
            return Ok(list);
        }
    }
}
