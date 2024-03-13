using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ModelServices;
using Services.ModelServices.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerConcurs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        #region Constructor
        private readonly ITransportService _transportService;
        public TransportController(ITransportService transportService)
        { 
            _transportService = transportService;
        }
        #endregion

        #region Crud
        [HttpGet("GetAll")] 
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _transportService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] TransportDTO transport)
        {
            try
            {
                return Ok(await _transportService.InsertAsync(transport));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] TransportDTO transport)
        {
            try
            {
                return Ok(await _transportService.UpdateAsync(transport));
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
                return Ok(await _transportService.DeleteAsync(new TransportDTO { IdTransport = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
         
    }
}
