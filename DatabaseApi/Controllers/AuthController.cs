using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DatabaseApi.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DatabaseApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOptions<JwtBearerTokenSettings> _jwtTokenOptions;
        public AuthController(IOptions<JwtBearerTokenSettings> jwtTokenOptions, UserManager<IdentityUser> userManager)
        {
            _jwtTokenOptions = jwtTokenOptions;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDetails userDetails)
        {
            // failed request
            // model state is wrong or post details is null
            if (!ModelState.IsValid || userDetails == null)
                return new BadRequestObjectResult(new {Message = "User Registration Failed"});

            var identityUser = new IdentityUser() { UserName = userDetails.Username, Email = userDetails.Email};
            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);

            // user registration failed in some sort
            // pass the errors back to the frontend
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary});
            }

            return Ok(new {Message = "Registration Successful"});

        }
    }
}