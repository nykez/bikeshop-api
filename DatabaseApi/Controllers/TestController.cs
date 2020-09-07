using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        //inject our db
        private readonly BIKE_SHOP_Context _context;
        public TestController(BIKE_SHOP_Context context)
        {
            _context = context;

        }

		// Route: api/test/
		[HttpGet]
		public async Task<IActionResult> GetAllBikes() {

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
			var bikeToReturn = await _context.Bicycle.FirstOrDefaultAsync(b => b.Customerid == custID);
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}

	}
}