using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApi;
using DatabaseApi.Dtos;

namespace DatabaseApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PaintsController : ControllerBase {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;
        public PaintsController(BikeShop_Context context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Paints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paint>>> GetPaint() {
            return Ok(await _context.Paint.ToListAsync());
        }

        [HttpGet("list")]
        public async Task<List<String>> GetColorlists() {
            return await _context.Paint.Select(p => p.Colorlist).Distinct().ToListAsync();

        }


        // GET: api/Paints/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaint(int id) {
            var paint = await _context.Paint.FindAsync(id);

            if(paint == null) {
                return NotFound();
            }

            return Ok(paint);
        }

        // PUT: api/Paints/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaint(int id, [FromBody] PaintToUpdate paint) {
            var toUpdatePaint = await _context.Paint.FirstOrDefaultAsync(b => b.Paintid == id);

            if(toUpdatePaint == null)
                return NoContent();

            _mapper.Map(paint, toUpdatePaint);
            await _context.SaveChangesAsync();
            return Ok(paint);
        }

        // POST: api/Paints
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostPaint([FromBody] PaintToCreate paint) {
            if(!ModelState.IsValid)
                return BadRequest();

            var newPaint = _mapper.Map<Paint>(paint);
            _context.Paint.Add(newPaint);

            await _context.SaveChangesAsync();
            return Ok(newPaint);
        }

        // DELETE: api/Paints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaint(int id) {
            var paint = await _context.Paint.FindAsync(id);

            if(paint == null)
                return NotFound();

            _context.Paint.Remove(paint);

            await _context.SaveChangesAsync();

            return Ok(paint);
        }

        private bool PaintExists(int id) {
            return _context.Paint.Any(e => e.Paintid == id);
        }
    }
}
