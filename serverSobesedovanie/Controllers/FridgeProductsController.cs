using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using serverSobesedovanie.DTO;
using serverSobesedovanie.Models;
using serverSobesedovanie.Services;
using System.Threading.Tasks;

namespace serverSobesedovanie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductsController : ControllerBase
    {
        IConfiguration _configuration;
        FridgeProductService fridgeProductService;
        ProductService productService;
        ApplicationContext db;

        public FridgeProductsController(IConfiguration configuration, FridgeProductService service, ProductService productService)
        {
            this._configuration = configuration;
            this.fridgeProductService = service;
            this.productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<FridgeProduct>> Add(FridgeProductDTO fridgeProductDTO)
        {
            var fridgeProduct = await fridgeProductService.Add(fridgeProductDTO);
            return Created("", fridgeProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FridgeProduct>> Delete(int id)
        {
            await fridgeProductService.Delete(id);
            return NoContent(); 
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<FridgeProduct>> AddProducts(int id, ProductDTO productDTO)
        {
            await productService.Update(id, productDTO);

            return Ok();
        }
    }
}
