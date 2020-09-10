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
    public class BikepartsController : ControllerBase
    {
        private readonly BikeShop_Context _context;

        public BikepartsController(BikeShop_Context context)
        {
            _context = context;
        }

        // GET: api/Bikeparts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bikeparts>>> GetBikeparts()
        {
            return await _context.Bikeparts.ToListAsync();
        }

        // GET: api/Bikeparts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bikeparts>> GetBikeparts(int id)
        {
            var bikeparts = await _context.Bikeparts.FindAsync(id);

            if (bikeparts == null)
            {
                return NotFound();
            }

            return bikeparts;
        }

        // PUT: api/Bikeparts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBikeparts(int id, Bikeparts bikeparts)
        {
            if (id != bikeparts.Serialnumber)
            {
                return BadRequest();
            }

            _context.Entry(bikeparts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikepartsExists(id))
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

        // POST: api/Bikeparts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bikeparts>> PostBikeparts(Bikeparts bikeparts)
        {
            _context.Bikeparts.Add(bikeparts);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BikepartsExists(bikeparts.Serialnumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBikeparts", new { id = bikeparts.Serialnumber }, bikeparts);
        }

        // DELETE: api/Bikeparts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bikeparts>> DeleteBikeparts(int id)
        {
            var bikeparts = await _context.Bikeparts.FindAsync(id);
            if (bikeparts == null)
            {
                return NotFound();
            }

            _context.Bikeparts.Remove(bikeparts);
            await _context.SaveChangesAsync();

            return bikeparts;
        }

        private bool BikepartsExists(int id)
        {
            return _context.Bikeparts.Any(e => e.Serialnumber == id);
        }
    }
}
