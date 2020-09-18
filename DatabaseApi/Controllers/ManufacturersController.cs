using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApi;
using AutoMapper;
using DatabaseApi.Dtos;


namespace DatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;
        public ManufacturersController(BikeShop_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturer()
        {
            return await _context.Manufacturer.ToListAsync();
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(int id)
        {
            var manufacturer = await _context.Manufacturer.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }

        // PUT: api/Manufacturers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManufacturer(int id, [FromForm]ManufacturerToUpdate manufacturer)
        {
            var toUpdateManufacturer = await _context.Manufacturer.FirstOrDefaultAsync(m => m.Manufacturerid == id);
            if(toUpdateManufacturer == null)
                return NoContent();
            // map our form data to our updated model
            _mapper.Map(manufacturer, toUpdateManufacturer);
            return Ok(await _context.SaveChangesAsync());
        }

        // POST: api/Manufacturers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> PostManufacturer([FromForm]ManufacturerToCreate manufacturer)
        {
            if(!ModelState.IsValid) {
                return BadRequest();
            }
            var newManufacturer = _mapper.Map<Manufacturer>(manufacturer);
            _context.Manufacturer.Add(newManufacturer);
            await _context.SaveChangesAsync();

            return Ok(newManufacturer);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manufacturer>> DeleteManufacturer(int id)
        {
            var manufacturer = await _context.Manufacturer.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturer.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return manufacturer;
        }
    }
}
