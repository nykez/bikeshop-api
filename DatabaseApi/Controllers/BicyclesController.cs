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

namespace DatabaseApi.Controllers
{
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycle>>> GetBicycle()
        {
            return await _context.Bicycle.ToListAsync();
        }

        // GET: api/Bicycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> GetBicycle(int id)
        {
            var bicycle = await _context.Bicycle.FindAsync(id);

            if (bicycle == null)
            {
                return NotFound();
            }

            return bicycle;
        }

        // PUT: api/Bicycles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBicycle(int id, [FromForm] BicycleToUpdate bicycle)
        {
           
            var toUpdateBicycle = await _context.Bicycle.FirstOrDefaultAsync(b => b.Serialnumber == id);
            if(toUpdateBicycle == null)
                return NoContent();
            // map our form data to our updated model
            //_mapper.Map(toUpdateBicycle, bicycle);
            var config = new MapperConfiguration(
                conf => {
                    conf.ForAllMaps((obj, cfg) => cfg.ForAllMembers(options => options.Condition((source, dest, sourceMember) => sourceMember != null)));
                    conf.CreateMap<BicycleToUpdate, Bicycle>().ForMember(toUpdateBicycle => toUpdateBicycle.Serialnumber, map => map.MapFrom(bicycle => bicycle));
            });
            
            _mapper.Map(bicycle, toUpdateBicycle);
/*			foreach(PropertyInfo p in typeof(Bicycle).GetProperties()) {
				// Debug.WriteLine(p.Name);
				PropertyInfo p2;
				if((p2 = typeof(BicycleToUpdate).GetProperty(p.Name)) != null) {
					var change = typeof(BicycleToUpdate).GetProperty(p.Name).GetValue(bicycle);
					if(change != null)
						typeof(Bicycle).GetProperty(p.Name).SetValue(toUpdateBicycle, change);
				}
			}*/
			return Ok(await _context.SaveChangesAsync());
        }

        // POST: api/Bicycles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostBicycle([FromForm] BicycleToCreate bicycle)
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

        private bool BicycleExists(int id)
        {
            return _context.Bicycle.Any(e => e.Serialnumber == id);
        }
    }
}
