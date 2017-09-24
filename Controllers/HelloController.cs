using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace QAware.OSS.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
		private IConfigurationRoot configuration;

		public HelloController(IConfigurationRoot configuration)
		{
			this.configuration = configuration;
		}

        [HttpGet]
        public virtual IActionResult Get()
        {
            string message = configuration["message"];
            return this.Ok(message == null ? "Hello BASTA 2017!" : message);
        }
    }
}
