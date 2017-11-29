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
        public IActionResult FindCustomer(int? id, bool isBrief)
        {


            string foundId = id.ToString();
          
            var customerList = new List<string>(System.IO.File.ReadAllLines(@"C:\Users\Marc\Desktop\Marc\VS grejjer\Avancerad webklientprogrammering asp.net\textfileproject\textfileproject\Data\TextFile.txt"));

            if (id == null)
            {
                return BadRequest("please write a number between 1-7");
            }

            if (id <= 0)
            {
                return BadRequest("program does not accept negative values");
            }
            foreach (var customerRow in customerList )
            {
                var arr = customerRow.Split(",");

                if (foundId == arr[0])
                {
                    var c = new Customer();

                    if (isBrief == true)
                    {
                        
                        var firstName = arr[1];
                        var lastName = arr[2];
                        
                        
                        
                        c.FirstName = firstName;
                        c.LastName = lastName;
                        
                    }
                    else
                    {
                        var cid = arr[0];
                        var firstName = arr[1];
                        var lastName = arr[2];
                        var email = arr[3];
                        var gender = arr[4];
                        var age = arr[5];
                        c.Id = int.Parse(cid);
                        c.FirstName = firstName;
                        c.LastName = lastName;
                        c.Email = email;
                        c.Gender = gender;
                        c.Age = int.Parse(age);
                        
                    }
                    return Ok(c);
                }
            }

            

            return NotFound();
        }

        
    }
}