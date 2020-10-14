using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// <summary>
    /// Bicycle controller for the API. Contains all CRUD operations for the Bicycle table.
    /// </summary>
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
        /// Returns all bicycles or specified bicycles if the URI contains a query string.
        /// </summary>
        /// <returns>A list of all bicycles or a list of requested bicycles based on a query.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycle>>> GetAll([FromQuery] UserParams userParams)
        {
            String qString = Request.QueryString.Value;
            var lambda = LambdaBuilder<Bicycle>.Builder(Request.QueryString.Value);
            var bicycles = _context.Bicycle.Include(p => p.Paint).OrderByDescending(u => u.Customerid).AsQueryable();
            if(lambda != null) {
                bicycles = bicycles.Where(lambda);
                if(Request.Query["paint"].Count > 0) {
                    Expression paintEx = Expression.Default(typeof(bool));
                    var parameters = Expression.Parameter(typeof(Bicycle), typeof(Bicycle).Name);
                    MemberExpression mem = Expression.Property(parameters, typeof(Bicycle).GetProperty("Paint"));
                    var prop = Expression.Property(mem, "Colorlist");
                    ConstantExpression cons;
                    String[] paintFilters = Request.Query["paint"][0].Split("|");
                    foreach(String f in paintFilters) {
                        cons = Expression.Constant(f);
                        paintEx = Expression.Or(paintEx, Expression.Equal(prop,cons));
					}
                    Expression<Func<Bicycle, bool>> ex = Expression.Lambda <Func<Bicycle, bool>>(paintEx, parameters);
                    bicycles = bicycles.Where(ex);
                }
            }
            return Ok(await PageList<Bicycle>.CreateAsync(bicycles, userParams.PageNumber, userParams.PageSize));
        }

        // GET: api/Bicycles/5
        /// <summary>S
        /// Returns a single Bicycle by serial number.
        /// </summary>
        /// <param name="id">The requested serial number.</param>
        /// <returns>A single bicycle of that serial number if the bicycle exists.</returns>
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
        /// Updates an existing bicycle with the data bassed in through a BicycleToUpdate DTO.
        /// </summary>
        /// <param name="id">The serial number of the bicycle wished to be changed.</param>
        /// <param name="bicycle">Bicycle DTO passed in through the front end.</param>
        /// <returns>A 201 message if the update was successful or an error if the update was not.</returns>
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
        /// Adds a bicycle to the database given that the data from a passed in DTO is valid.
        /// </summary>
        /// <param name="bicycle">The bicycle DTO created by the front end.</param>
        /// <returns>A 200 message if the post was successful or a BadRequest message if it was not.</returns>
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
        /// Removes a bicycle from the database given a valid Serial Number.
        /// </summary>
        /// <param name="id">Serial Number for the bicycle wished to be removed.</param>
        /// <returns>The bicycle if the bicycle was deleted or a NotFound message if it was not found.</returns>
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
