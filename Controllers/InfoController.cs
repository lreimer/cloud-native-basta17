using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QAware.OSS.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public virtual IActionResult Get()
        {
            return this.Ok("Hello BASTA! 2017");
        }
    }
}
