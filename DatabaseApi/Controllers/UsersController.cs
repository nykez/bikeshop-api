using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Claims;

namespace DatabaseApi.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly BikeShop_Context _context;
        private readonly IMapper _autoMapper;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(BikeShop_Context context, IMapper autoMapper, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _autoMapper = autoMapper;
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == id);


            if (user == null)
            {
                return NoContent();
            }

            return Ok(user);
        }
    }
}