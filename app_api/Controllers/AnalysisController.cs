using Domain.Models;
using MedApp.Domain.DTO;
using MedApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : Controller
    {
        private IAnalysisService _service;

        public AnalysisController(IAnalysisService services)
        {
            _service = services;
        }

        // GET api/<AnalysisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalysisResultDTO>> Get(int id)
        {
            try
            {
                var analysis = await _service.GetAnalysisResultByIdAsync(id);

                return Ok(analysis);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AnalysisController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AnalysisResultDTO analysis)
        {
            try
            {
                var id = await _service.CreateAnalysisResultAsync(analysis);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AnalysisController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AnalysisResultDTO analysis)
        {
            try
            {
                await _service.UpdateAnalysisResultByIdAsync(id, analysis);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AnalysisController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAnalysisResultByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
