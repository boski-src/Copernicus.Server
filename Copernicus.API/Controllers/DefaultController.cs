using Microsoft.AspNetCore.Mvc;

namespace Copernicus.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => NoContent();
    }
}