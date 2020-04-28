using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API.Models;
using Newtonsoft.Json.Linq;

namespace REST_API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CustomersController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomers(long id, string contact_email, string job_title)
        {
            var Customers = await _context.Customers.FindAsync(id);

            if (Customers == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["id"] = Customers.id;
            jsonGet["contact_email"] = Customers.contact_email;
            return Content  (jsonGet.ToString(), "application/json");
        }

  

    [HttpPut("{id}")]
        public IActionResult PutCustomers(long id, Customers item)
        {
            var emp = _context.Customers.Find(id); 
            if (emp == null)
            {
                return NotFound();
            }


            _context.Customers.Update(emp);
            _context.SaveChanges();

            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to Customers id : " + id ;
            return Content  (jsonPut.ToString(), "application/json");
        
        }


        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers Customers)
        {
            _context.Customers.Add(Customers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomers", new { id = Customers.id }, Customers);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomers(long id)
        {
            var Customers = await _context.Customers.FindAsync(id);
            if (Customers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(Customers);
            await _context.SaveChangesAsync();

            return Customers;
        }

        private bool CustomersExists(long id)
        {
            return _context.Customers.Any(e => e.id == id);
        }
    }
}
