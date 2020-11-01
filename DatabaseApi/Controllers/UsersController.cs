using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using DatabaseApi.Dtos;

namespace DatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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

        /// <summary>
        /// Returns all Users in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        
        /// <summary>
        /// Returns a User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            // attempt to find the user
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == id);

            // map user to DTO (this protects password hashes, personal data.. etc)
            var userToReturn = _autoMapper.Map<UserToReturn>(user);

            if (user== null)
            {
                // return a 204 if user doesnt exist
                return NoContent();
            }

            // return the roles attached to the user
            userToReturn.Roles = await _userManager.GetRolesAsync(user);

            return Ok(userToReturn);
        }
    }
}