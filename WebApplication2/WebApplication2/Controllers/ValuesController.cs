using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet, Route("kalle")]
        public IEnumerable<string> Kalle()
        {
            return new string[] { "Marc", "Uddenfeldt" };
        }

    }
}
