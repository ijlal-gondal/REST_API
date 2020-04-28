using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API.Models;
using Newtonsoft.Json.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace REST_API.Controllers
{
    [Route("api/quotes")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public QuotesController(DatabaseContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotes>>> GetQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }


    [HttpGet("listofQuotes")]
        public  ActionResult<List<Quotes>> GetQuotesWhoAreNotCustomer()
         {
           
   
            IQueryable<Quotes> Lead =

            from lead in _context.Quotes 
       
            where lead.created_at >= DateTime.Now.AddDays(-30)

            select lead; 

            if (Lead == null)
            {
                return NotFound();
            }


            return Lead.ToList();
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<Quotes>> GetQuotes(long id)
        {
            var Quotes = await _context.Quotes.FindAsync(id);

            if (Quotes == null)
            {
                return NotFound();
            }

        
            return Quotes;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotes(long id, Quotes Quotes)
        {
            if (id != Quotes.id)
            {
                return BadRequest();
            }

            _context.Entry(Quotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to Quotes id : " + id;
            return Content  (jsonPut.ToString(), "application/json");

        }

        [HttpPost]
        public async Task<ActionResult<Quotes>> PostQuotes(Quotes Quotes)
        {
            _context.Quotes.Add(Quotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuotes", new { id = Quotes.id }, Quotes);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Quotes>> DeleteQuotes(long id)
        {
            var Quotes = await _context.Quotes.FindAsync(id);
            if (Quotes == null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(Quotes);
            await _context.SaveChangesAsync();

            return Quotes;
        }

        private bool QuotesExists(long id)
        {
            return _context.Quotes.Any(e => e.id == id);
        }
    }
}
