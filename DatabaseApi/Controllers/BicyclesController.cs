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
using System.Reflection;
using System.Diagnostics;
using DatabaseApi.Helpers;

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
        /// <summary>
        /// Returns all bicycles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycle>>> GetAll([FromQuery] UserParams userParams)
        {
            var lambda = LambdaBuilder<Bicycle>.Builder(Request.QueryString.Value);
            var bicycles = _context.Bicycle.Include(p => p.Paint).OrderByDescending(u => u.Customerid).AsQueryable();
            if(lambda != null) {
                bicycles = bicycles.Where(lambda);
            }
            // do some filtering...
            // ...
            // ..

            return Ok(await PageList<Bicycle>.CreateAsync(bicycles, userParams.PageNumber, userParams.PageSize));
        }

        // GET: api/Bicycles/5
        /// <summary>
        /// Returns Bicycles by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> GetBicycle(int id)
        {
            var bicycle = await _context.Bicycle.Include(p => p.Paint).Where(b => b.Serialnumber == id).FirstOrDefaultAsync();

            if (bicycle == null)
            {
                return NotFound();
            }

            return bicycle;
        }

        /// <summary>
        /// Adds existing bicycle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bicycle"></param>
        /// <returns>error if encountered</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBicycle(int id, [FromBody] BicycleToUpdate bicycle)
        {
            var toUpdateBicycle = await _context.Bicycle.FirstOrDefaultAsync(b => b.Serialnumber == id);
            if(toUpdateBicycle == null)
                return NoContent();
            // map our form data to our updated model
            _mapper.Map(bicycle, toUpdateBicycle);
			return Ok(await _context.SaveChangesAsync());
        }

        
        /// <summary>
        /// Adds Bicycles provided Bicycles object
        /// </summary>
        /// <param name="bicycle"></param>
        /// <returns>new Bicycle</returns>
        [HttpPost]
        public async Task<IActionResult> PostBicycle([FromBody] BicycleToCreate bicycle)
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
        /// <summary>
        /// Deletes Bicycle provided id as param
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bicycle</returns>
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

        /// <summary>
        /// Verify id exists in database for Bicycle
        /// </summary>
        /// <param name="id"></param>
        /// <returns>boolean</returns>
        private bool BicycleExists(int id)
        {
            return _context.Bicycle.Any(e => e.Serialnumber == id);
        }
    }
}
