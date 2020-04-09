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
    [Route("api/interventions")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public InterventionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // GET: api/Interventions/5


 //https://stackoverflow.com/questions/16507222/create-json-object-dynamically-via-javascript-without-concate-strings
 
//  return this.Content(returntext, "application/json");

        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetInterventions(long id, string Status)
        {
            var Interventions = await _context.Interventions.FindAsync(id);

            if (Interventions == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["status"] = Interventions.Status;
            return Content  (jsonGet.ToString(), "application/json");
        }

        // PUT: api/Interventions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutInterventions(long id, Interventions Interventions)
        // {
        //     if (id != Interventions.id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(Interventions).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!InterventionsExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
            
        //     var jsonPut = new JObject ();
        //     jsonPut["Update"] = "Update done to Interventions id : " + id;
        //     return Content  (jsonPut.ToString(), "application/json");

        // }



   [HttpPut("{id}")]
        public IActionResult PutInterventionStatus(long id, Interventions item)
        {
            var inte = _context.Interventions.Find(id); 
            if (inte == null)
            {
                return NotFound();
            }
            inte.Status = item.Status;

            _context.Interventions.Update(inte);
            _context.SaveChanges();
    
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to Intervention id : " + id + " to the status : " + inte.Status;
            return Content  (jsonPut.ToString(), "application/json");
        
        }




        // POST: api/Interventions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Interventions>> PostInterventions(Interventions Interventions)
        {
            _context.Interventions.Add(Interventions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterventions", new { id = Interventions.id }, Interventions);
        }

        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interventions>> DeleteInterventions(long id)
        {
            var Interventions = await _context.Interventions.FindAsync(id);
            if (Interventions == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(Interventions);
            await _context.SaveChangesAsync();

            return Interventions;
        }

        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.id == id);
        }
    }
}
