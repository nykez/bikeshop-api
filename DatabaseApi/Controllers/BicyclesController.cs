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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DatabaseApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class BicyclesController : ControllerBase {
		private readonly BikeShop_Context _context;
		private readonly IMapper _mapper;
		private readonly MonitoringService _monitoringService;
		private readonly MonitoringServiceModels.Transaction transaction = new MonitoringServiceModels.Transaction();
        private readonly MonitoringServiceModels.ErrorRate errorRate = new MonitoringServiceModels.ErrorRate();


        private const string transPost = "api/transaction/post";
        private const string errPost = "api/error/post";
        private const string AdminRole = "Admin";


        public BicyclesController(BikeShop_Context context, IMapper mapper, MonitoringService monitoringService) {
			_context = context;
			_mapper = mapper;
			_monitoringService = monitoringService;
        }

		// GET: api/Bicycles
		/// <summary>
		/// Returns all bicycles
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Bicycle>>> GetAll([FromQuery] UserParams userParams) {
			string qString = Request.QueryString.Value;
			var lambda = LambdaBuilder<Bicycle>.Builder(Request.QueryString.Value);
			var bicycles = _context.Bicycle.Include(p => p.Paint).OrderByDescending(u => u.Customerid).AsQueryable();
			if(lambda != null) {
				bicycles = bicycles.Where(lambda);
				if(Request.Query["paint"].Count > 0) {
					Expression paintEx = Expression.Default(typeof(bool));
					
					var parameters = Expression.Parameter(typeof(Bicycle), typeof(Bicycle).Name);
					MemberExpression mem = Expression.Property(parameters, typeof(Bicycle).GetProperty("Paint"));
					var prop = Expression.Property(mem, "Colorlist");
                    string[] paintFilters = Request.Query["paint"][0].Split("|");
					foreach(string f in paintFilters) {
                        ConstantExpression cons = Expression.Constant(f);
                        paintEx = Expression.Or(paintEx, Expression.Equal(prop, cons));
                    }
					Expression<Func<Bicycle, bool>> ex = Expression.Lambda<Func<Bicycle, bool>>(paintEx, parameters);
					bicycles = bicycles.Where(ex);
				}
			}
			// do some filtering...
			// ...
			// ..
            await TimeStampTransaction();
			return Ok(await PageList<Bicycle>.CreateAsync(bicycles, userParams.PageNumber, userParams.PageSize));
		}

		// GET: api/Bicycles/5
		/// <summary>S
		/// Returns Bicycles by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<Bicycle>> GetBicycle(int id) {

			var bicycle = await _context.Bicycle.Include(p => p.Paint).Where(b => b.Serialnumber == id).FirstOrDefaultAsync();

			if(bicycle == null) {
                await TimeStampError();
				return NotFound();
			}
            await TimeStampTransaction();
			return bicycle;
		}

		/// <summary>
		/// Adds existing bicycle
		/// </summary>
		/// <param name="id"></param>
		/// <param name="bicycle"></param>
		/// <returns>error if encountered</returns>
		[HttpPut("{id}")]
		[Authorize(Roles = AdminRole)]
		public async Task<IActionResult> UpdateBicycle(int id, [FromBody] BicycleToUpdate bicycle) {
			var toUpdateBicycle = await _context.Bicycle.FirstOrDefaultAsync(b => b.Serialnumber == id);
			if(toUpdateBicycle == null) {
                await TimeStampError();
                return NoContent();
            }
			// map our form data to our updated model
			_mapper.Map(bicycle, toUpdateBicycle);
            await TimeStampTransaction();
			return Ok(await _context.SaveChangesAsync());
		}

        private async Task TimeStampError() {
            this.errorRate.time_Stamp = DateTime.Now;
            await this._monitoringService.SendUpdateAsync(errPost, errorRate);
        }

        private async Task TimeStampTransaction() {
            transaction.time_Stamp = DateTime.Now;
            await _monitoringService.SendUpdateAsync(transPost, transaction);
		}

        /// <summary>
		/// Adds Bicycles provided Bicycles object
		/// </summary>
		/// <param name="bicycle"></param>
		/// <returns>new Bicycle</returns>
		[HttpPost]
		[Authorize(Roles = AdminRole)]
		public async Task<IActionResult> CreateBicycle([FromBody] BicycleToCreate bicycle) {

			if(!ModelState.IsValid) {
                await TimeStampError();
				return BadRequest();
			}
			var newBicycle = _mapper.Map<Bicycle>(bicycle);
			_context.Bicycle.Add(newBicycle);
			await _context.SaveChangesAsync();
            await TimeStampTransaction();
			return Ok(newBicycle);
		}

		// DELETE: api/Bicycles/5
		/// <summary>
		/// Deletes Bicycle provided id as param
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Bicycle</returns>
		[HttpDelete("{id}")]
		[Authorize(Roles = AdminRole)]
		public async Task<IActionResult> DeleteBicycle(int id) {
			var bicycle = await _context.Bicycle.FindAsync(id);
			if (bicycle == null) {
                await TimeStampError();
				return NotFound();
            }

			_context.Bicycle.Remove(bicycle);
			await _context.SaveChangesAsync();
            await TimeStampTransaction();
			return Ok(bicycle);
		}
    }
}
