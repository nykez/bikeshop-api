using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Customer.ToListAsync());
        }
        
        /// <summary>
        /// Returns a customer by their CustomerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(b => b.Customerid == id);

            return Ok(customer);
        }

        /// <summary>
        /// Returns all customers matching the given zipcode
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        [HttpGet("zipcode/{zipcode}")]
        public async Task<IActionResult> GetByZipcode(string zipcode)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(b => b.Zipcode == zipcode);

            return Ok(customer);
        }

        /// <summary>
        /// Returns all customers matching the given cityid
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        
        [HttpGet("city/{cityid}")]
        public async Task<IActionResult> GetByCityId(int cityid)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(b => b.Cityid == cityid);

            return Ok(customer);
        }
    }
}