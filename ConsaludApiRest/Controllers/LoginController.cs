using System;
using CConsalud.Model.Responses;
using Consalud.Commons.contracts;
using Consalud.Model.Requests;
using ConsaludApiRest.Jwt;
using ConsaludApiRest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ConsaludApiRest.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private IJwtService jwtService;
        private IUserServices pUserServices;

        public LoginController(IJwtService pJwtService, IUserServices userServices)
		{
            jwtService = pJwtService;
            pUserServices = userServices;
        }

        [AllowAnonymous]
        [HttpPost(Name = "user")]
        [SwaggerOperation(OperationId = "user", Summary ="Create new user", Description = "This method allows you to register a new user")]
        public AuthResponse Users(AuthRequest request)
        {
            return pUserServices.CreateUser(request);
        }

        [AllowAnonymous]
        [HttpPost(Name = "auth")]
        [SwaggerOperation(OperationId = "auth", Summary ="User login", Description = "This method allows you to log in, validating username and password.")]
        public IActionResult Auth(AuthRequest request)
        {
            var result = pUserServices.LoginUser(request);
            if (result == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(result.Token))
            {
                return Unauthorized();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}

