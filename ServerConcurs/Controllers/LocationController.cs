using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ModelServices.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerConcurs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        #region Constructor
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService) 
        {
            _locationService = locationService;
        }
        #endregion

        #region Crud

        [HttpGet("GetAll")] 
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                return Ok(await _locationService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")] 
        public async Task<IActionResult> Insert([FromBody] LocationDTO location)
        {
            try
            {
                return Ok(await _locationService.InsertAsync(location));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")] 
        public async Task<IActionResult> Update([FromBody] LocationDTO location)
        {
            try
            {
                return Ok(await _locationService.UpdateAsync(location));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _locationService.DeleteAsync(new LocationDTO { IdLocation = id }));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
