using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
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
			var lambda = LambdaBuilder<Bicycle>.Builder(Request.QueryString.Value, "bicycle");
			Debug.WriteLine(Request.Path.Value);
			if(lambda != null) {
				return Ok(_context.Bicycle.Where(lambda));
			} 
			return Ok(await _context.Bicycle.ToListAsync());
		}

		[HttpGet("purchase")]
		public async Task<IActionResult> Purchase() {
			// If wanting to do things not via a query string, you replace the route from the path(Or get it however else) and then pass in the rest of the data, as well as whatever expression "type"(defined by us) you want back.
			// It doesn't mess with routing, nor does anything with HTTP. It just builds lambda expressions.
			// This will allow you to access some things past queries as well, such as 
			var lambda = LambdaBuilder<Bicycle>.URIBuilder(Request.Path.Value.Replace("/api/test/purchase", ""), "purchase");
			return Ok(_context.Bicycle.Where(b => b.Serialnumber == 7));
		}

		[HttpGet("{**.}")]
		public async Task<IActionResult> GetBikes() {
			var lambda = LambdaBuilder<Bicycle>.URIBuilder(Request.Path.Value.Replace("/api/test/", ""), "bicycle");
			//Debug.WriteLine(Request.Path.Value.Replace("/api/test/", ""));
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
	}
}