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

        // GET: api/Retailstores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Retailstore>>> GetRetailstore()
        {
            return await _context.Retailstore.ToListAsync();
        }

        // GET: api/Retailstores/5
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
        /// Updates a existing customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="retailstore"></param>
        /// <response code="200">the updated cistomer</response>
        /// <response code="204">Customer to update is null</response>
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

        // POST: api/Retailstores
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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

        // DELETE: api/Retailstores/5
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

        private bool RetailstoreExists(int id)
        {
            return _context.Retailstore.Any(e => e.Storeid == id);
        }
    }
}
