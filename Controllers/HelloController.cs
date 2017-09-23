using Microsoft.AspNetCore.Mvc;

namespace QAware.OSS.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        [HttpGet]
        public virtual IActionResult Get()
        {
            return this.Ok("Hello BASTA! 2017");
        }
    }
}
