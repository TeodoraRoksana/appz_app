using Domain.Models;
using MedApp.Domain.DTO;
using MedApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersWardsController : Controller
    {
        private IUserService _userService;

        public UsersWardsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<UsersWardsController>/UserId
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserData>>> Get(int id)
        {
            try
            {
                var users = await _userService.GetAllWardsForUser(id);

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
