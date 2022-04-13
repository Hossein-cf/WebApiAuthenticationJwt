//using Microsoft.AspNetCore.Authorization;
using WebApiAuthentication.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiAuthentication.Models;

namespace WebApiAuthentication.Controllers
{


    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admins")]
     
        public IActionResult AdminsEndPoint()
        {
            var currentUser=GetCurrentUser();
            return Ok($"hi {currentUser.GivenName}, you a0re an {currentUser.Role}");
        }

        [AllowAnonymous]
        [HttpGet("Public")]
        public IActionResult Public()
        {

            return Ok("Hi \n this end point is public ");
        }
        private User GetCurrentUser()
        {
            var user = (User)HttpContext.Items["User"];
            return user== null ? null : user;
           /* if (identity != null)
            {
                var userClaim = identity.Claims;
                return new User
                {
                    UserName = userClaim.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaim.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaim.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    SurName = userClaim.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaim.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }*/
        }


    }
}
