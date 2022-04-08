using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public string Get()

        {
            return new string("12333");
        }
        [HttpGet("{id}")]
        public string Get(int id)

        {
            return new string($"{id}");
        }
    }
}
