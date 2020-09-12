using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Text.RegularExpressions;
using AutoMapper;
using DatabaseApi.Dtos;

namespace DatabaseApi.Controllers
{
	[Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMapper _mapper;
        //inject our db
        private readonly BikeShop_Context _context;
        public TestController(BikeShop_Context context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

		/// <summary>
		/// Returns all Bicycles
		/// </summary>
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

        [HttpPost]
        public async Task<IActionResult> CreateBicycle([FromForm] BicycleToCreate bicycle) {
            // Missing parameters
            // More info in response
            if(!ModelState.IsValid) {
                return BadRequest();
            }

            // map the customer model
            // USES: automapper instead of handtyped
            var newBicycle = _mapper.Map<Bicycle>(bicycle);

            _context.Add(newBicycle);

            await _context.SaveChangesAsync();

            return Ok(newBicycle);
        }
    }
}