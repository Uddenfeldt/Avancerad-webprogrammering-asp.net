using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webapi2.Controllers
{
    [Route("WebApi")]
    public class ValuesController : Controller
    {

        [HttpGet, Route("GetDish")]

        public IActionResult GetDish(string dish)
        {
            
            if (dish == "ägg")
            {
                return Ok("Åhnej du ska inte äta ägg");
            }
            else
            {
                return Ok($"åh va gott med {dish}");
            }
        }
        [HttpGet, Route("GetNumber")]
        public IActionResult GetNumber(int number)
        {
            int answer = number * number;

            return Ok($"{number} * {number} = {answer} ");
        }

        [HttpGet, Route("Numbers")]
        public IActionResult Numbers(int number1, int number2)
        {
            string result = "";
            for (int i = number1; i <= number2; i++)
            {
                result = result + "," + i;
            }
            return Ok(result);
        }

        [HttpGet, Route("GetColor")]
        public IActionResult GetColor(string color)
        {
            return Content($"<body style='background-color:{color}'></body>", "text/html"); 
        }

        [HttpGet, Route("GetPainting")]
        public IActionResult GetPainting(string painter, int paintedDate)
        {
            string response = $"Du angav Konstnären {painter} och datumet {paintedDate}";
            return Ok(response);
        }

        
    }
}
