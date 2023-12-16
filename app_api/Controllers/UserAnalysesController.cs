using Domain.Models;
using MedApp.Domain.DTO;
using MedApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnalysesController : Controller
    {
        private IAnalysisService _service;

        public UserAnalysesController(IAnalysisService services)
        {
            _service = services;
        }

        // GET api/<UserAnalysesController>/UserId
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AnalysisShortDataDTO>>> Get(int id)
        {
            try
            {
                var analyses = await _service.GetAllAnalysisForUser(id);

                return Ok(analyses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
