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

        [HttpGet, Route("")]

        public IActionResult GetCustomers()
        {
            var list = databaseContext.Customers.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Customer obj)
        {

            databaseContext.Add(obj);
            databaseContext.SaveChanges();

            return new ObjectResult("Customer add successfully!");
        }

        [Route("/api/DeleteCustomer/{id}")]

        public IActionResult DeleteCustomer(Customer customer)
        {
            databaseContext.Remove(customer);
            return new ObjectResult("Customer deleted successfully");
        }

        [Route("/api/EditCustomer")]
        public IActionResult EditCustomer([FromBody] Customer obj)
        {
            databaseContext.Update(obj);
            return new ObjectResult("Customer updated successfully!");
        }
    }
}
