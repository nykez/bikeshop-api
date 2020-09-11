using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApi;
using AutoMapper;

namespace DatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicyclesController : ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;
        public BicyclesController(BikeShop_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Bicycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycle>>> GetBicycle()
        {
            return await _context.Bicycle.ToListAsync();
        }

        // GET: api/Bicycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> GetBicycle(int id)
        {
            var bicycle = await _context.Bicycle.FindAsync(id);

            if (bicycle == null)
            {
                return NotFound();
            }

            return bicycle;
        }

        // PUT: api/Bicycles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBicycle(int id, Bicycle bicycle)
        {
            if (id != bicycle.Serialnumber)
            {
                return BadRequest();
            }

            _context.Entry(bicycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicycleExists(id))
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

        // POST: api/Bicycles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostBicycle([FromForm] BicycleToCreate bicycle)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newBicycle = _mapper.Map<Bicycle>(bicycle);
            _context.Bicycle.Add(newBicycle);
            await _context.SaveChangesAsync();

            return Ok(newBicycle);
        }

        // DELETE: api/Bicycles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bicycle>> DeleteBicycle(int id)
        {
            var bicycle = await _context.Bicycle.FindAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }

            _context.Bicycle.Remove(bicycle);
            await _context.SaveChangesAsync();

            return bicycle;
        }

        private bool BicycleExists(int id)
        {
            return _context.Bicycle.Any(e => e.Serialnumber == id);
        }
    }
}
