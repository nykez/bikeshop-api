using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
namespace DatabaseApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase {
		private readonly BikeShop_Context _context;

		public CityController(BikeShop_Context context) {
			_context = context;
		}

		[HttpGet]
		[HttpGet("q")]
		public async Task<IActionResult> GetCities() {
			var lambda = LambdaBuilder<City>.Builder(Request.QueryString.Value, typeof(City), "city");
			if(lambda != null) {
				return Ok(_context.City.Where(lambda));
			}
			return Ok(await _context.City.ToListAsync());
		}
	}
}
