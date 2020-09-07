using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DatabaseApi.Dtos;

namespace DatabaseApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly BikeShop_Context _context;
        public CustomerController(BikeShop_Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all customers in the database
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Customer.ToListAsync());
        }
        
        /// <summary>
        /// Returns a customer by their CustomerId
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Ok</response>
        /// <response code="204">No customers could be found</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(b => b.Customerid == id);

            if (customer == null)
            {
                return NoContent();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Returns all customers matching the given zipcode
        /// </summary>
        /// <param name="zipcode"></param>
        /// <response code="200">Ok</response>
        /// <response code="204">No customers could be found</response>
        [HttpGet("zipcode/{zipcode}")]
        public async Task<IActionResult> GetByZipcode(string zipcode)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(b => b.Zipcode == zipcode);

            if (customer == null)
            {
                return NoContent();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Returns all customers matching the given cityid
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns>Customer</returns>
        /// <response code="200">Ok</response>
        /// <response code="204">No customers could be found</response>
        [HttpGet("city/{cityid}")]
        public async Task<IActionResult> GetByCityId(int cityid)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(b => b.Cityid == cityid);

            if (customer == null)
            {
                return NoContent();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromForm] CustomerToCreate customer)
        {
            // Missing parameters
            // More info in response
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(customer);
        }
    }
}