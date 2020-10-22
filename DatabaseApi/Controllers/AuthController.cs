using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DatabaseApi.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DatabaseApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace DatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtBearerTokenSettings _jwtTokenOptions;
        public AuthController(IOptions<JwtBearerTokenSettings> jwtTokenOptions, UserManager<IdentityUser> userManager)
        {
            _jwtTokenOptions = jwtTokenOptions.Value;
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


        private object GenerateToken(IdentityUser identityUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtTokenOptions.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, identityUser.Email),
                    new Claim(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.UtcNow.AddSeconds(_jwtTokenOptions.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtTokenOptions.Audience,
                Issuer = _jwtTokenOptions.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}