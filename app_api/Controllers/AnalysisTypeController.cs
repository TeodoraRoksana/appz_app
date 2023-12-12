using Domain.Models;
using MedApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisTypeController : Controller
    {
        private IAnalysisService _service;

        public AnalysisTypeController(IAnalysisService services)
        {
            _service = services;
        }

        // GET: api/<ManagerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysisType>>> Get()
        {
            return Ok(await _service.GetAllAnalysisTypes());
        }
    }
}
