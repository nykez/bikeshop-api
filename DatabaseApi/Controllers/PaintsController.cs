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
    public class PaintsController : ControllerBase
    {
        private readonly BikeShop_Context _context;

        public PaintsController(BikeShop_Context context)
        {
            _context = context;
        }

        // GET: api/Paints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paint>>> GetPaint()
        {
            return await _context.Paint.ToListAsync();
        }

        [HttpGet("list")]
        public async Task<List<String>> GetColorlists() {
            return await _context.Paint.Select(p => p.Colorlist).Distinct().ToListAsync();

        }


        // GET: api/Paints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paint>> GetPaint(int id)
        {
            var paint = await _context.Paint.FindAsync(id);

            if (paint == null)
            {
                return NotFound();
            }

            return paint;
        }

        // PUT: api/Paints/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaint(int id, Paint paint)
        {
            if (id != paint.Paintid)
            {
                return BadRequest();
            }

            _context.Entry(paint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintExists(id))
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

        // POST: api/Paints
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Paint>> PostPaint(Paint paint)
        {
            _context.Paint.Add(paint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaint", new { id = paint.Paintid }, paint);
        }

        // DELETE: api/Paints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paint>> DeletePaint(int id)
        {
            var paint = await _context.Paint.FindAsync(id);
            if (paint == null)
            {
                return NotFound();
            }

            _context.Paint.Remove(paint);
            await _context.SaveChangesAsync();

            return paint;
        }

        private bool PaintExists(int id)
        {
            return _context.Paint.Any(e => e.Paintid == id);
        }
    }
}
