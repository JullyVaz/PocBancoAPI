using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.API.Controllers
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
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] AccountViewModel accountViewModel)
        {
            return Ok(await _accountService.Insert (accountViewModel));
        }
    }
}
