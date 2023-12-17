using Domain.Models;
using MedApp.Domain.DTO;
using MedApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDataDTO>> Get(int id)
        {
            try
            {
                var analysis = await _service.GetUserByIdAsync(id);

                return Ok(analysis);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
