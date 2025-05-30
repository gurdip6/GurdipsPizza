using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Core.Interfaces;
using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;
using System.Security.Claims;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountEntity accountEntity)
        {
            try
            {
                string token = await _accountService.Register(accountEntity);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                string token = await _accountService.Login(loginDTO);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            try
            {
                string accountid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                string username = User.FindFirst(ClaimTypes.Name)?.Value;
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                string phone = User.FindFirst(ClaimTypes.MobilePhone)?.Value;
                return Ok(new
                {
                    AccountID = accountid,
                    Username = username,
                    Email = email,
                    Phone = phone
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> Update(AccountEntity accountEntity)
        {
            try
            {
                accountEntity.AccountID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                await _accountService.Update(accountEntity);
                return Ok("Updated Account Information");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
