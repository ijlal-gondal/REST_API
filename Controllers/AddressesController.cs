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
    [Route("api/addresses")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AddressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Addresses>>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        // GET: api/Addresses/5


 //https://stackoverflow.com/questions/16507222/create-json-object-dynamically-via-javascript-without-concate-strings
 
//  return this.Content(returntext, "application/json");

        [HttpGet("{id}")]
        public async Task<ActionResult<Addresses>> GetAddresses(long id, string Status)
        {
            var Addresses = await _context.Addresses.FindAsync(id);

            if (Addresses == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["status"] = Addresses.status;
            return Content  (jsonGet.ToString(), "application/json");
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutAddresses(long id, Addresses Addresses)
        // {
        //     if (id != Addresses.id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(Addresses).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!AddressesExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
            
        //     var jsonPut = new JObject ();
        //     jsonPut["Update"] = "Update done to Addresses id : " + id;
        //     return Content  (jsonPut.ToString(), "application/json");

        // }



   [HttpPut("{id}")]
        public IActionResult PutBatteryStatus(long id, Addresses item)
        {
            var bat = _context.Addresses.Find(id); 
            if (bat == null)
            {
                return NotFound();
            }
            bat.status = item.status;

            _context.Addresses.Update(bat);
            _context.SaveChanges();
    
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to battery id : " + id + " to the status : " + bat.status;
            return Content  (jsonPut.ToString(), "application/json");
        
        }




        // POST: api/Addresses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Addresses>> PostAddresses(Addresses Addresses)
        {
            _context.Addresses.Add(Addresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddresses", new { id = Addresses.id }, Addresses);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Addresses>> DeleteAddresses(long id)
        {
            var Addresses = await _context.Addresses.FindAsync(id);
            if (Addresses == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(Addresses);
            await _context.SaveChangesAsync();

            return Addresses;
        }

        private bool AddressesExists(long id)
        {
            return _context.Addresses.Any(e => e.id == id);
        }
    }
}
