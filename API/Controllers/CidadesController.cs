using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        [HttpGet("helloworld")]
        public string Hello()
        {
            return "Hello World";
        }
    }
}
