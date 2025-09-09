using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PruebaTecnica.Api.Data;
using PruebaTecnica.Api.Models;
using PruebaTecnica.Api.Services;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Identity.Data;

namespace PruebaTecnica.Api.Controllers
{
   
    [ApiController]
    [Route("api/pruebatecnica/users")]
    public class UsersController : ControllerBase
    {

        private readonly IAuthService _authService;

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var (jwt, externalToken) = await _authService.LoginAsync(login.Username, login.Password);
            return Ok(new { jwt, external_token = externalToken });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _authService.GetUsersAsync();
            return Content(users, "application/json");
        }
    }
}

