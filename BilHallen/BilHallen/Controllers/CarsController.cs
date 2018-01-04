using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BilHallen.Entities;

namespace BilHallen.Controllers
{
    [Route("api/cars")]
    public class CarsController : Controller
    {
        private DatabaseContext databaseContext;

        public CarsController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            databaseContext.Database.EnsureCreated();
        }

        [HttpGet, Route("GetCars")]
        public IActionResult GetCars()
        {
            var list = databaseContext.Cars.ToList();
            return Ok(list);
        }

        [HttpPost, Route("AddCar")]
        public IActionResult AddCar([FromBody]Car obj)
        {
            databaseContext.Add(obj);
            databaseContext.SaveChanges();

            return Ok();
        }

        [HttpDelete, Route("DeleteCar/{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = databaseContext.Cars.First(c => c.Id == id);

            databaseContext.Remove(car);
            databaseContext.SaveChanges();
            return Ok();
        }

        [HttpPut, Route("EditCar")]
        public IActionResult EditCar([FromBody]Car obj)
        {
            databaseContext.Update(obj);
            databaseContext.SaveChanges();
            return new ObjectResult("Car updated successfully!");
        }


    }
}