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
    public class ProductsController : ControllerBase
    {
        IConfiguration _configuration;
        ProductService productsService;
        ApplicationContext db;
        public ProductsController(IConfiguration configuration, ProductService service)
        {
            this._configuration = configuration;
            this.productsService = service;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Add(ProductDTO request)
        {
            var fridge = await productsService.Add(request);
            return Created("", fridge);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            await productsService.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Product>> Update(int id, ProductDTO productDTO)
        {
            var product = await productsService.Update(id, productDTO);
            if(product == null)
            {
                return NoContent();
            }
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await productsService.Get(id);
            return Ok(product);
        }
    }
}
