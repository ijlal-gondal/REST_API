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


        [HttpGet]
        public async Task<ActionResult<List<Interventions>>> GetInterventionsList()
        {

          var list =  await _context.Interventions.ToListAsync();

               if (list == null)
            {
                return NotFound();
            }

     
        List<Interventions> listInterventions = new List<Interventions>();



        foreach (var intervention in list){

            if (intervention.Status == "Pending" || intervention.Status == "InProgress" ){
         
            listInterventions.Add(intervention);



            }
        }


             return listInterventions;

            }



        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetInterventions(long id, string Status)
        {
            var Interventions = await _context.Interventions.FindAsync(id);

            if (Interventions == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["Status"] = Interventions.Status;
            return Content  (jsonGet.ToString(), "application/json");
        }





    [HttpGet("get/Status/all")]

        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
        return await _context.Interventions.ToListAsync();
        }


        [HttpGet("get/Status/{id}")]
        public IEnumerable<Interventions> GetInterventionsId(long id)
        {
        IQueryable<Interventions> Interventions =
        from inte in _context.Interventions
        where inte.id == id
        select inte;
        return Interventions.ToList();
        }


        [HttpGet("get/Status/Pending")]
        public IEnumerable<Interventions> GetInterventionsPending()
        {
        IQueryable<Interventions> Interventions =
        from inte in _context.Interventions
        where (inte.Status == "Pending") && (!inte.started_at.HasValue)
        select inte;
        return Interventions.ToList();
        }


        [HttpGet("get/Status/completed")]
        public IEnumerable<Interventions> GetInterventionsActive()
        {
        IQueryable<Interventions> Interventions =
        from inte in _context.Interventions
        where inte.Status == "Completed"
        select inte;
        return Interventions.ToList();
        }


        [HttpGet("get/Status/inprogress")]
        public IEnumerable<Interventions> GetInterventionsIntervention()
        {
        IQueryable<Interventions> Interventions =
        from inte in _context.Interventions
        where inte.Status == "InProgress"
        select inte;
        return Interventions.ToList();
        }


        [HttpGet("get/Status/others")]
        public IEnumerable<Interventions> GetInterventionsOthers()
        {
        IQueryable<Interventions> Interventions =
        from inte in _context.Interventions
        where inte.Status != "Completed" && inte.Status != "Pending" && inte.Status != "InProgress"
        select inte;
        return Interventions.ToList();

        }



        [HttpPut("{id}/start")]
        public IActionResult PutInterventionStart(long id, Interventions item)
        {
            var inter = _context.Interventions.Find(id); 
            if (inter == null)
            {
                return NotFound();
            }
            inter.started_at = item.started_at;
            inter.Status = item.Status;

            _context.Interventions.Update(inter);
            _context.SaveChanges();
    
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to intervention id : " + id + " start time set as : " + inter.started_at +  " and the Status us: " + inter.Status;
            return Content  (jsonPut.ToString(), "application/json");
        
        }

        [HttpPut("{id}/end")]
        public IActionResult PutInterventionEnd(long id, Interventions item)
        {
            var inter = _context.Interventions.Find(id); 
            if (inter == null)
            {
                return NotFound();
            }
            inter.ended_at = item.ended_at;
            inter.Status = item.Status;

            _context.Interventions.Update(inter);
            _context.SaveChanges();
    
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to intervention id : " + id + " end time set as : " + inter.ended_at + " and the Status us: " + inter.Status;
            return Content  (jsonPut.ToString(), "application/json");
        
        }



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
