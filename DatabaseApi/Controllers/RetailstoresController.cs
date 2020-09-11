using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApi;

namespace DatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailstoresController : ControllerBase
    {
        private readonly BikeShop_Context _context;

        public RetailstoresController(BikeShop_Context context)
        {
            _context = context;
        }

        // GET: api/Retailstores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Retailstore>>> GetRetailstore()
        {
            return await _context.Retailstore.ToListAsync();
        }

        // GET: api/Retailstores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Retailstore>> GetRetailstore(int id)
        {
            var retailstore = await _context.Retailstore.FindAsync(id);

            if (retailstore == null)
            {
                return NotFound();
            }

            return retailstore;
        }

        // PUT: api/Retailstores/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRetailstore(int id, Retailstore retailstore)
        {
            if (id != retailstore.Storeid)
            {
                return BadRequest();
            }

            _context.Entry(retailstore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetailstoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Retailstores
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Retailstore>> PostRetailstore(Retailstore retailstore)
        {
            _context.Retailstore.Add(retailstore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRetailstore", new { id = retailstore.Storeid }, retailstore);
        }

        // DELETE: api/Retailstores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Retailstore>> DeleteRetailstore(int id)
        {
            var retailstore = await _context.Retailstore.FindAsync(id);
            if (retailstore == null)
            {
                return NotFound();
            }

            _context.Retailstore.Remove(retailstore);
            await _context.SaveChangesAsync();

            return retailstore;
        }

        private bool RetailstoreExists(int id)
        {
            return _context.Retailstore.Any(e => e.Storeid == id);
        }
    }
}
