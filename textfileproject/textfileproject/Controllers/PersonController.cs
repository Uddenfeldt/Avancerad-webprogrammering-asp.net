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


            foreach (var customerRow in customerList )
            {
                //return Ok(id);
            }

            

            return Ok();
        }
    }
}