using MedApp.Domain.DTO;
using MedApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Post([FromBody] LoginData loginData)
        {
            try
            {
                var loginResponse = await _loginService.LoginUser(loginData);

                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
