using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiAuthentication.Models;
using WebApiAuthentication.Authorization;

namespace WebApiAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IJwtUtils _JwtUtils;

        public LoginController( IJwtUtils jwtUtils) { 
        
            _JwtUtils = jwtUtils;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = _JwtUtils.GenerateToken(user);
                return Ok(token);
            }
            return NotFound("not found");

        }


        private User Authenticate(UserLogin userLogin)
        {
            var currentUser = UserConstants.users.FirstOrDefault(u => u.UserName.ToLower() == userLogin.UserName.ToLower() && u.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;

            }
            return null;
        }
    }

}
