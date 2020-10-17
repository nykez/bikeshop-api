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
using System.Reflection;
using System.Diagnostics;
using DatabaseApi.Helpers;


namespace DatabaseApi.Controllers
{  
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController: ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;
        private readonly MonitoringService _monitoringService;
        private readonly MonitoringServiceModels.Transaction t;
        private readonly MonitoringServiceModels.ErrorRate errorRate;

        public ComponentController(BikeShop_Context context, IMapper mapper, MonitoringService monitoringService)
        {
            _context = context;
            _mapper = mapper;
            _monitoringService = monitoringService;
            t = new MonitoringServiceModels.Transaction();
            errorRate = new MonitoringServiceModels.ErrorRate();
        }

        /// <summary>
        /// Get All Compoents
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetAll([FromQuery] UserParams userParams)
        {
            var lambda = LambdaBuilder<Component>.Builder(Request.QueryString.Value);
            var components = _context.Component.OrderByDescending(u => u.Componentid).AsQueryable();
            if(lambda != null) {
                components = components.Where(lambda);
            }

            return Ok(await PageList<Component>.CreateAsync(components, userParams.PageNumber, userParams.PageSize));
        }

      

        /// <summary>
        /// Returns a component by their StoreId
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">returns a Retailstore</response>
        /// <response code="204">Retailstore is null</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Component>> GetComponent(int id)
        {
            var component = await _context.Component.FindAsync(id);

            if (component == null)
            {
                return NotFound();
            }

            return component;
        }

        /// <summary>
        /// Updates a existing component
        /// </summary>
        /// <param name="id"></param>
        /// <param name="component"></param>
        /// <response code="200">the updated retailstore</response>
        /// <response code="204">Retailstore to update is null</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComponent(int id, [FromBody] ComponetToUpdate component)
        {
            var toUpdateComponent = await _context.Component.FirstOrDefaultAsync(c => c.Componentid == id);
            if (toUpdateComponent == null)
                return NoContent();
            // map our form data to our updated model
            _mapper.Map(component, toUpdateComponent);
            return Ok(await _context.SaveChangesAsync());
        }

        /// <summary>
        /// Creates a new component
        /// </summary>
        /// <param name="component"></param>
        /// <response code="200">the newly created retail</response>
        /// <response code="204">ModelState error</response>
        [HttpPost]
        public async Task<IActionResult> CreateComponent([FromBody] ComponetToCreate component)
        {
            // Missing parameters
            // More info in response
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // map the customer model
            // USES: automapper instead of handtyped
            var newComponent = _mapper.Map<Component>(component);

            _context.Add(newComponent);

            await _context.SaveChangesAsync();

            return Ok(newComponent);
        }

        /// <summary>
        /// Deletes an existing component
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">success</response>
        /// <response code="204">Retailstore is null</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Component>> DeleteComponent(int id)
        {
            var component = await _context.Component.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }

            _context.Component.Remove(component);
            await _context.SaveChangesAsync();

            return component;
        }
    }
}