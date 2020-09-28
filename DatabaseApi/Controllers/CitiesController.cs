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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;

        public CitiesController(BikeShop_Context context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Returns all city in the database
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.City.ToListAsync());
        }
        /// <summary>
        /// Returns a city by their CityId
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">returns a City</response>
        /// <response code="204">City is nill</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var city = await _context.City.FirstOrDefaultAsync(c => c.Cityid == id);

            if (city == null)
            {
                return NoContent();
            }

            return Ok(city);
        }

        /// <summary>
        /// Updates a existing city
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        /// <response code="200">the updated city</response>
        /// <response code="204">City to update is null</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromForm] CityToUpdate city)
        {
            var toUpdateCity = await _context.City.FirstOrDefaultAsync(c => c.Cityid == id);
            if (toUpdateCity == null)
                return NoContent();
            // map our form data to our updated model
            _mapper.Map(city, toUpdateCity);
            return Ok(await _context.SaveChangesAsync());
        }

        /// <summary>
        /// Creates a new city
        /// </summary>
        /// <param name="city"></param>
        /// <response code="200">the newly created city</response>
        /// <response code="204">ModelState error</response>
        [HttpPost]
        public async Task<IActionResult> CreateCity([FromForm] CityToCreate city)
        {
            // Missing parameters
            // More info in response
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // map the customer model
            // USES: automapper instead of handtyped
            var newCity = _mapper.Map<City>(city);

            _context.Add(newCity);

            await _context.SaveChangesAsync();

            return Ok(newCity);
        }

        /// <summary>
        /// Deletes an existing city
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">success</response>
        /// <response code="204">City is null</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var cityToDelete = await _context.City.FirstOrDefaultAsync(c => c.Cityid == id);
            if (cityToDelete != null)
            {
                _context.Remove(cityToDelete);
                return Ok(await _context.SaveChangesAsync());
            }
            else
            {
                return BadRequest();
            }
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.Cityid == id);
        }
    }
}
