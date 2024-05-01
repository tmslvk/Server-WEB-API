using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace serverSobesedovanie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MainController(IConfiguration configuration)
        {
            
            _configuration = configuration;

            //http delete fridge using getfidge from service
        }
    }
}
