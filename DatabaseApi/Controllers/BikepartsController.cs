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
        /// <summary>
        /// Returns all Bikeparts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bikeparts>>> GetBikeparts()
        {
            return await _context.Bikeparts.ToListAsync();
        }

        // GET: api/Bikeparts/5
        /// <summary>
        /// Returns bikeparts by serial number and componentid
        /// </summary>
        /// <param name="serialnumber"></param>
        /// <param name="componentid"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds existing bikeparts
        /// </summary>
        /// <param name="serialnumber"></param>
        /// <param name="componentid"></param>
        /// <param name="bikeparts"></param>
        /// <returns>error if encountered</returns>
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

        /// <summary>
        /// Adds Bikeparts provided bikeparts object
        /// </summary>
        /// <param name="bikeparts"></param>
        /// <returns>new bikeparts</returns>
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
        /// <summary>
        /// Deletes bikeparts provided id as param
        /// </summary>
        /// <param name="serialnumber"></param>
        /// <param name="componentid"></param>
        /// <returns>bikeparts</returns>
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

        /// <summary>
        /// Check if bikeparts exist
        /// </summary>
        /// <param name="serialnumber"></param>
        /// <param name="componentid"></param>
        /// <returns>boolean</returns>
        private bool BikepartsExists(int serialnumber, int componentid)
        {
            return _context.Bikeparts.Any(b => b.Serialnumber == serialnumber && b.Componentid == componentid);
        }
    }
}
