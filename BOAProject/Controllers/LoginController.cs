using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOAProject.Core.AppServices;
using BOAProject.Core.Entity;
using BOAProject.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOAProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthenticationHelper authenticationHelper;

        public LoginController(IUserService userService, IAuthenticationHelper authService)
        {
            this.userService = userService;
            authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = userService.ReadUsers().FirstOrDefault(u => u.Email == model.Email);
            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                id = user.ID,
                email = user.Email,
                token = authenticationHelper.GenerateToken(user),
                isAdmin = user.IsAdmin

            });
        }
    }
}