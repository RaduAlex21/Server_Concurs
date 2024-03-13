using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ModelServices;
using Services.ModelServices.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Claims;
using Utils.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerConcurs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Constructor
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
             _accountService = accountService;
        }
        #endregion

        #region Crud 

        [HttpGet("GetAll")] 

        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _accountService.GetAllAsync());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")] 
        public async Task<IActionResult> Insert([FromBody] AccountDTO profile)
        {
            try
            {
                return Ok(await _accountService.InsertAsync(profile));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")] 
        public async Task<IActionResult> Update([FromBody] AccountDTO profile)
        {
            try
            {
                return Ok(await _accountService.UpdateAsync(profile));
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
                return Ok(await _accountService.DeleteAsync(new AccountDTO { IdAccount = id }));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion


      /*  [HttpGet("username/{userName}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> SearchByUserName(string userName)
        {
            try
            {
                var person = await _accountService.SearchByUserNameAsync(userName);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [HttpGet("myProfile")]
        [Authorize(Roles = "Admin,Driver")]
        public async Task<IActionResult> GetMyData()
        {
            try
            {
                var driverId = int.Parse(User.FindFirst("Identifier")?.Value);
                var person = await _accountService.SearchByIdAsync(driverId);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #region Other Operation
        /*[HttpGet("username/{userName}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> SearchByUserName(string userName)
        {
            try
            {
                var person = await _accountService.SearchByUserNameAsync(userName);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/
         
        /*[HttpGet("email/{email}")]
        [Authorize(Roles = "Admin")]
        
        public async Task<IActionResult> SearchByEmail(string email)
        {
            try
            {
                var person = await _accountService.SearchByEmailAsync(email);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/
        #endregion

        #region Private methods
        private async Task CheckRole(AccountDTO user)
        {
            var userId = int.Parse(User.FindFirst("Identifier")?.Value);
            var userData = await _accountService.SearchByIdAsync(user.IdAccount);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userId.Equals(user.IdAccount) && userData.Role != user.Role)
                throw new ValidationException("You can't edit your role, contact the owner for this task");

            if (user.IdAccount != userId && role != Role.Admin.ToString())
                throw new ValidationException("You don't have access to modify, view or insert this value");

        }
        #endregion 
    }
}
