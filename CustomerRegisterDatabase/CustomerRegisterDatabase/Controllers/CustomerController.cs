using CustomerRegisterDatabase.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CustomerRegisterDatabase.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private DatabaseContext databaseContext;

        public CustomerController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            databaseContext.Database.EnsureCreated();
        }

        [HttpGet, Route("GetCustomers")]

        public IActionResult GetCustomers()
        {
            var list = databaseContext.Customers.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {

            databaseContext.Add(customer);
            databaseContext.SaveChanges();

            return Ok(customer.Id + " " + customer.FirstName);
        }
        
    }
}
