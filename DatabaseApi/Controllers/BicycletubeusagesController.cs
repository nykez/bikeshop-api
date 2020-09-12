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
    public class BicycletubeusagesController : ControllerBase
    {
        private readonly BikeShop_Context _context;

        public BicycletubeusagesController(BikeShop_Context context)
        {
            _context = context;
        }

        // GET: api/Bicycletubeusages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycletubeusage>>> GetBicycletubeusage()
        {
            return await _context.Bicycletubeusage.ToListAsync();
        }

        // GET: api/Bicycletubeusages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycletubeusage>> GetBicycletubeusage(int id)
        {
            var bicycletubeusage = await _context.Bicycletubeusage.FindAsync(id);

            if (bicycletubeusage == null)
            {
                return NotFound();
            }

            return bicycletubeusage;
        }

        // PUT: api/Bicycletubeusages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBicycletubeusage(int id, Bicycletubeusage bicycletubeusage)
        {
            if (id != bicycletubeusage.Serialnumber)
            {
                return BadRequest();
            }

            _context.Entry(bicycletubeusage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicycletubeusageExists(id))
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

        // POST: api/Bicycletubeusages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bicycletubeusage>> PostBicycletubeusage(Bicycletubeusage bicycletubeusage)
        {
            _context.Bicycletubeusage.Add(bicycletubeusage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BicycletubeusageExists(bicycletubeusage.Serialnumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBicycletubeusage", new { id = bicycletubeusage.Serialnumber }, bicycletubeusage);
        }

        // DELETE: api/Bicycletubeusages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bicycletubeusage>> DeleteBicycletubeusage(int id)
        {
            var bicycletubeusage = await _context.Bicycletubeusage.FindAsync(id);
            if (bicycletubeusage == null)
            {
                return NotFound();
            }

            _context.Bicycletubeusage.Remove(bicycletubeusage);
            await _context.SaveChangesAsync();

            return bicycletubeusage;
        }

        private bool BicycletubeusageExists(int id)
        {
            return _context.Bicycletubeusage.Any(e => e.Serialnumber == id);
        }
    }
}
