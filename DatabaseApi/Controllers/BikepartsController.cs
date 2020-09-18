using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApi;
using DatabaseApi.Dtos;
using AutoMapper;

namespace DatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikepartsController : ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;
        public BikepartsController(BikeShop_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Bikeparts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bikeparts>>> GetBikeparts()
        {
            return await _context.Bikeparts.ToListAsync();
        }

        // GET: api/Bikeparts/5
        [HttpGet("{serialnumber}/{componentid}")]
        public async Task<ActionResult<Bikeparts>> GetBikeparts(int serialnumber, int componentid)
        {
            var bikeparts = await _context.Bikeparts.FindAsync(serialnumber, componentid);

            if (bikeparts == null)
            {
                return NotFound();
            }

            return bikeparts;
        }

        // PUT: api/Bikeparts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{serialnumber}/{componentid}")]
        public async Task<IActionResult> UpdateBikeparts(int serialnumber, int componentid,[FromForm]BikepartsToUpdate bikeparts)
        {
            var toUpdateBikeParts = await _context.Bikeparts.FirstOrDefaultAsync(b => b.Serialnumber == serialnumber && b.Componentid == componentid);
            if(toUpdateBikeParts == null)
                return NoContent();
            // map our form data to our updated model
            _mapper.Map(bikeparts, toUpdateBikeParts);
            return Ok(await _context.SaveChangesAsync());
        }

        // POST: api/Bikeparts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bikeparts>> PostBikeparts([FromForm] BikepartsToCreate bikeparts)
        {
            if(!ModelState.IsValid) {
                return BadRequest();
            }
            var newBikeparts = _mapper.Map<Bikeparts>(bikeparts);
            _context.Bikeparts.Add(newBikeparts);
            await _context.SaveChangesAsync();

            return Ok(newBikeparts);
        }

        // DELETE: api/Bikeparts/5
        [HttpDelete("{serialnumber}/{componentid}")]
        public async Task<ActionResult<Bikeparts>> DeleteBikeparts(int serialnumber, int componentid)
        {
            var bikeparts = await _context.Bikeparts.FindAsync(serialnumber, componentid);
            if (bikeparts == null)
            {
                return NotFound();
            }

            _context.Bikeparts.Remove(bikeparts);
            await _context.SaveChangesAsync();

            return bikeparts;
        }

        private bool BikepartsExists(int serialnumber, int componentid)
        {
            return _context.Bikeparts.Any(b => b.Serialnumber == serialnumber && b.Componentid == componentid);
        }
    }
}
