using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DatabaseApi.Models;
using DatabaseApi.Context;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        // inject our db
        private readonly ModelContext _context;
        public TestController(ModelContext context)
        {
            _context = context;

        }

        // Route: api/test/
        [HttpGet]
        public async Task<IActionResult> GetAllBikes()
        {
            
            return Ok(await _context.Bicycle.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBike(int id)
        {
            var bikeToReturn = _context.Bicycle.Select(b => b.Serialnumber == id).FirstOrDefaultAsync();

            if (bikeToReturn == null)
            {
                return NotFound();
            }

            return Ok(bikeToReturn);
        }
    }
}