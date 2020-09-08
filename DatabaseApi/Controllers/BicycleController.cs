using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DatabaseApi.Controllers
{
	[Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        //inject our db
        private readonly BikeShop_Context _context;
        public TestController(BikeShop_Context context)
        {
            _context = context;

        }

		/// <summary>
		/// Returns all Bicycles
		/// </summary>
		[HttpGet]
		public async Task<IActionResult> GetAllBikes() {

			return Ok(await _context.Bicycle.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBike(int id) {
			var bikeToReturn = await _context.Bicycle.FirstOrDefaultAsync(b => b.Serialnumber == id);

			if(bikeToReturn == null) {
				return NotFound();
			}

			return Ok(bikeToReturn);
		}

		// https://localhost:44349/api/test/bycustid?custid=15
		[HttpGet("bycustid")]
		public async Task<IActionResult> GetBikeByCustID(int custID) {
			var bikeToReturn = await _context.Bicycle.Where(b => b.Customerid == custID).ToListAsync();
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}
		[HttpGet("byid")]
		public async Task<IActionResult> GetBikeByID(int ID) {
			var bikeToReturn = await _context.Bicycle.Where(b => b.Serialnumber == ID).ToListAsync();
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}

		[HttpGet("framesize")]
		public async Task<IActionResult> GetBikeByFrameSize(int frameSize) {
			var bikeToReturn = await _context.Bicycle.Where(b => b.Framesize == frameSize).ToListAsync();
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}

		[HttpGet("modeltype")]
		public async Task<IActionResult> GetBikeByModelType(String modeltype) {
			var bikeToReturn = await _context.Bicycle.Where(b => b.Modeltype== modeltype).ToListAsync();
			if(bikeToReturn == null) return NotFound();
			return Ok(bikeToReturn);
		}

		[HttpGet("b")]
		public async Task<IActionResult> Builder() {
			String[] selections = Request.QueryString.Value.Replace("?", "").Split("&");
			var parameters = Expression.Parameter(typeof(Bicycle), "bicycle");
			MemberExpression prop;
			ConstantExpression cons;
			Expression expression = Expression.Empty();
			if(selections.Length > 0 && selections[0] != "") {

				// A bit of hackery, the default bool expression is FALSE, so in order to create a bool expression, it must be notted
				expression = Expression.Not(Expression.Default(typeof(bool)));
				// A list for all of the expressions to be stored in for later Anding with the original expression(maybe just and them instead of this?)
				List<Expression> expressionList = new List<Expression>();
				// The field to the expression being extracted
				String field;
				// The operator to the expression being extracted
				String op;
				// The value to the expression being extracted
				String value;
				// A string to store each part of the expression(only one split happens)
				String[] expressionSplit;
				foreach(String q in selections) {
					// We need to replace the instances of these chars to the string representation like is done with space
					expressionSplit = Regex.Split(q, "(=|%3C|%3E)");
					// Store the field
					field = expressionSplit[0].ToLower();
					// Store the operator
					op = expressionSplit[1];
					// Store the value and convert space back into actual space char
					value = expressionSplit[2].ToLower().Replace("%20", " ");
					// Create the expression property
					prop = Expression.Property(parameters, field);
					// Create the expression Constant
					cons = Expression.Constant(value);
					switch(op) {
						case "=": { // If the operator is an equals
								// Add the expression to the original
								expression = Expression.And(expression, Expression.Equal(prop, cons));
								break;
							}
					}
				}
			}
			// If the expression never changed to the boolean type, we want to return all bikes(query was not specified)
			if(expression.Type != typeof(void)) {
				// Create a lambda expression
				var lambda = Expression.Lambda<Func<Bicycle, bool>>(expression, parameters);
				// And pass it in as the where clause
				return Ok(_context.Bicycle.Where(lambda));
			} else {// else(no query) return all bikes
				return Ok(_context.Bicycle.ToList());
			}
		}
	}
}