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
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController: ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _mapper;

        public ComponentController(BikeShop_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}