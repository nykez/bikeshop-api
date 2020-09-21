using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApi;
using AutoMapper;
using DatabaseApi.Dtos;

namespace DatabaseApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RetailstoresController : ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;

        public RetailstoresController(BikeShop_Context context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        /// <summary>
        /// Returns all retailstores in the database
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Retailstore>>> GetRetailstore()
        {
            return await _context.Retailstore.ToListAsync();
        }

        /// <summary>
        /// Returns a retailstore by their StoreId
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">returns a Retailstore</response>
        /// <response code="204">Retailstore is null</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Retailstore>> GetRetailstore(int id)
        {
            var retailstore = await _context.Retailstore.FindAsync(id);

            if (retailstore == null)
            {
                return NotFound();
            }

            return retailstore;
        }

        /// <summary>
        /// Updates a existing retailstore
        /// </summary>
        /// <param name="id"></param>
        /// <param name="retailstore"></param>
        /// <response code="200">the updated retailstore</response>
        /// <response code="204">Retailstore to update is null</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromForm] RetailstoreToUpdate retailstore)
        {
            var toUpdateRetailstore = await _context.Retailstore.FirstOrDefaultAsync(r => r.Storeid == id);
            if (toUpdateRetailstore == null)
                return NoContent();
            // map our form data to our updated model
            _mapper.Map(retailstore, toUpdateRetailstore);
            return Ok(await _context.SaveChangesAsync());
        }
        /// <summary>
        /// Creates a new retailstore
        /// </summary>
        /// <param name="retailstore"></param>
        /// <response code="200">the newly created retail</response>
        /// <response code="204">ModelState error</response>
        [HttpPost]
        public async Task<IActionResult> CreateRetailstore([FromForm] RetailstoreToCreate retailstore)
        {
            // Missing parameters
            // More info in response
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // map the customer model
            // USES: automapper instead of handtyped
            var newRetailstore = _mapper.Map<Retailstore>(retailstore);

            _context.Add(newRetailstore);

            await _context.SaveChangesAsync();

            return Ok(newRetailstore);
        }

        /// <summary>
        /// Deletes an existing retailstore
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">success</response>
        /// <response code="204">Retailstore is null</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Retailstore>> DeleteRetailstore(int id)
        {
            var retailstore = await _context.Retailstore.FindAsync(id);
            if (retailstore == null)
            {
                return NotFound();
            }

            _context.Retailstore.Remove(retailstore);
            await _context.SaveChangesAsync();

            return retailstore;
        }

        /// <summary>
        /// Verify id exists in database for RetailStore
        /// </summary>
        /// <param name="id"></param>
        /// <returns>boolean</returns>
        private bool RetailstoreExists(int id)
        {
            return _context.Retailstore.Any(e => e.Storeid == id);
        }
    }
}
