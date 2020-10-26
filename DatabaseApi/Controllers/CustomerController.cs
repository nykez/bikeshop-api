using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DatabaseApi.Dtos;
using AutoMapper;
using System.Diagnostics;
using DatabaseApi.Helpers;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace DatabaseApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;
        private readonly MonitoringService _monitoringService;
        private readonly MonitoringServiceModels.Transaction t;
        private readonly MonitoringServiceModels.ErrorRate errorRate;
        public CustomerController(BikeShop_Context context, IMapper mapper, MonitoringService monitoringService)
        {
            _mapper = mapper;
            _context = context;
            _monitoringService = monitoringService;
             t = new MonitoringServiceModels.Transaction();
            errorRate = new MonitoringServiceModels.ErrorRate();
        }

        /// <summary>
        /// Returns all customers in the database
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserParams userParams)
        {
            var lambda = LambdaBuilder<Customer>.Builder(Request.QueryString.Value);
            var customers = _context.Customer.OrderByDescending(u => u.Customerid).AsQueryable();
            if(lambda != null) {
                Debug.WriteLine(lambda.ToString());
                customers = customers.Where(lambda);
			}
            // do some filtering...
            // ...
            // ..

            t.time_Stamp = DateTime.Now;
            await _monitoringService.SendUpdateAsync("api/transaction/post", t);

            return Ok(await PageList<Customer>.CreateAsync(customers, userParams.PageNumber, userParams.PageSize));
        }

        /// <summary>
        /// Returns a customer by their CustomerId
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">returns a Customer</response>
        /// <response code="204">Customer is nill</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(b => b.Customerid == id);

            if (customer == null)
            {
 
                errorRate.time_Stamp = DateTime.Now;
                await _monitoringService.SendUpdateAsync("api/error/post", errorRate);
                return NoContent();
            }
            
            t.time_Stamp = DateTime.Now;
            await _monitoringService.SendUpdateAsync("api/transaction/post", t);

            return Ok(customer);
        }

        /// <summary>
        /// Returns all customers matching the given zipcode
        /// </summary>
        /// <param name="zipcode"></param>
        /// <response code="200">List of customers</response>
        /// <response code="204">Customer list is null/empty</response>
        [HttpGet("zipcode/{zipcode}")]
        public async Task<IActionResult> GetByZipcode(string zipcode)
        {
            var customer = await _context.Customer.Where(c => c.Zipcode == zipcode).ToListAsync();

            if (customer == null)
            {
                errorRate.time_Stamp = DateTime.Now;
                await _monitoringService.SendUpdateAsync("api/error/post", errorRate);
                return NoContent();
            }

            t.time_Stamp = DateTime.Now;
            await _monitoringService.SendUpdateAsync("api/transaction/post", t);
            return Ok(customer);
        }

        /// <summary>
        /// Returns all customers matching the given cityid
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns>Customer</returns>
        /// <response code="200">List of customers</response>
        /// <response code="204">Customer list is null</response>
        [HttpGet("city/{cityid}")]
        public async Task<IActionResult> GetByCityId(int cityid)
        {
            var customer = await _context.Customer.Where(b => b.Cityid == cityid).ToListAsync();

            if (customer == null)
            {
                errorRate.time_Stamp = DateTime.Now;
                await _monitoringService.SendUpdateAsync("api/error/post", errorRate);
                return NoContent();
            }

            t.time_Stamp = DateTime.Now;
            await _monitoringService.SendUpdateAsync("api/transaction/post", t);
            return Ok(customer);
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <response code="200">the newly created customer</response>
        /// <response code="204">ModelState error</response>
        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerToCreate customer)
        {
            // Missing parameters
            // More info in response
            if (!ModelState.IsValid)
            {
                errorRate.time_Stamp = DateTime.Now;
                await _monitoringService.SendUpdateAsync("api/error/post", errorRate);
                return BadRequest();
            }

            // map the customer model
            // USES: automapper instead of handtyped
            var newCustomer = _mapper.Map<Customer>(customer);

            _context.Add(newCustomer);

            await _context.SaveChangesAsync();

            t.time_Stamp = DateTime.Now;
            await _monitoringService.SendUpdateAsync("api/transaction/post", t);
            return Ok(newCustomer);
        }

        /// <summary>
        /// Updates a existing customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <response code="200">the updated cistomer</response>
        /// <response code="204">Customer to update is null</response>
        [HttpPut("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerToUpdate customer)
        {
            var toUpdateCustomer = await _context.Customer.FirstOrDefaultAsync(c => c.Customerid == id);
            if (toUpdateCustomer == null)
            {
                errorRate.time_Stamp = DateTime.Now;
                await _monitoringService.SendUpdateAsync("api/error/post", errorRate);
                return NoContent();
            }
            // map our form data to our updated model
            _mapper.Map(customer, toUpdateCustomer);

            t.time_Stamp = DateTime.Now;
            await _monitoringService.SendUpdateAsync("api/transaction/post", t);
            return Ok(await _context.SaveChangesAsync());
        }

        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">success</response>
        /// <response code="204">Customer is null</response>
        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customerToDelete = await _context.Customer.FirstOrDefaultAsync(c => c.Customerid == id);
            if (customerToDelete != null)
            {
                _context.Remove(customerToDelete);
                t.time_Stamp = DateTime.Now;
                await _monitoringService.SendUpdateAsync("api/transaction/post", t);
                return Ok(await _context.SaveChangesAsync());
            }
            else
            {
                errorRate.time_Stamp = DateTime.Now;
                await _monitoringService.SendUpdateAsync("api/error/post", errorRate);
                return BadRequest();
            }
        }
    }
}


