using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using textfileproject.Models;

namespace textfileproject.Controllers
{
    [Route("Person")]
    public class PersonController : Controller
    {
        [HttpGet,Route("FindCustomer")]
        public IActionResult FindCustomer(int? id)
        {
            
          
            var customerList = new List<string>(System.IO.File.ReadAllLines(@"C:\Users\Marc\Desktop\Marc\VS grejjer\Avancerad webklientprogrammering asp.net\textfileproject\textfileproject\Data\TextFile.txt"));

            if (id == null )
            {
                return BadRequest("Please type something between 1-7");
            }

            else if (id < 0)
            {
                return BadRequest("you cant put in minus");
            }
            foreach (var row in customerList)
            {
                return Ok(customerList);
            }
            
            return Ok(customerList);
        }
    }
}