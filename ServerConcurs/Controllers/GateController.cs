using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ModelServices.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerConcurs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        #region Constructor
        private readonly IGateService _gateService;
        public GateController(IGateService gateService)
        {
            _gateService = gateService;
        }

        #endregion

        #region Crud 

        [HttpGet("GetAll")] 
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _gateService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")] 
        public async Task<IActionResult> Insert([FromBody] GateDTO gate)
        {
            try
            {
                return Ok(await _gateService.InsertAsync(gate));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")] 
        public async Task<IActionResult> Update([FromBody] GateDTO gate)
        {
            try
            {
                return Ok(await _gateService.UpdateAsync(gate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _gateService.DeleteAsync(new GateDTO { IdGate = id }));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
         
    }
}
