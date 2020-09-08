using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApi.Controllers
{
	[Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        //inject our db
        private readonly BikeShop_Context _context;
        public TestController(BikeShop_Context context)
        {
            _context = context;

        }

		/// <summary>
		/// Returns all Bicycles
		/// </summary>
		[HttpGet]
		[HttpGet("q")]
		public async Task<IActionResult> GetAllBikes() {
			var lambda = LambdaBuilder<Bicycle>.Builder(Request.QueryString.Value, typeof(Bicycle), "bicycle");
			if(lambda != null) {
				return Ok(_context.Bicycle.Where(lambda));
			} 
			return Ok(await _context.Bicycle.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBike(int id) {
			var bikeToReturn = await _context.Bicycle.FirstOrDefaultAsync(b => b.Serialnumber == id);

			if(bikeToReturn == null) {
				return NotFound();
			}

			return Ok(bikeToReturn);
		}

		// https://localhost:44349/api/test/bycustid?custid=15
		[HttpGet("bycustid")]
		public async Task<IActionResult> GetBikeByCustID(int custID) {
			var bikeToReturn = await _context.Bicycle.Where(b => b.Customerid == custID).ToListAsync();
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}
		[HttpGet("byid")]
		public async Task<IActionResult> GetBikeByID(int ID) {
			var bikeToReturn = await _context.Bicycle.Where(b => b.Serialnumber == ID).ToListAsync();
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}

		[HttpGet("framesize")]
		public async Task<IActionResult> GetBikeByFrameSize(int frameSize) {
			var bikeToReturn = await _context.Bicycle.Where(b => b.Framesize == frameSize).ToListAsync();
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}

		[HttpGet("modeltype")]
		public async Task<IActionResult> GetBikeByModelType(String modeltype) {
			var bikeToReturn = await _context.Bicycle.Where(b => b.Modeltype== modeltype).ToListAsync();
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}
	}
}