using MedApp.Domain.DTO;
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

        // GET: api/<AnalysisTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysisTypeDTO>>> Get()
        {
            return Ok(await _service.GetAllAnalysisTypesAsync());
        }

        // GET api/<AnalysisTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalysisTypeDTO>> Get(int id)
        {
            try
            {
                var analysisType = await _service.GetAnalysisTypesByIdAsync(id);

                return Ok(analysisType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AnalysisTypeController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AnalysisTypeDTO analysisType)
        {
            try
            {
                var id = await _service.CreateAnalysisTypeAsync(analysisType);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AnalysisTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AnalysisTypeDTO analysisType)
        {
            try
            {
                await _service.UpdateAnalysisTypeByIdAsync(id, analysisType);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AnalysisTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAnalysisTypeByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
