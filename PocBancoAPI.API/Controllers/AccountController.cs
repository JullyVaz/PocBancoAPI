using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocBancoAPI.Services;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;
using System.Net;

namespace PocBancoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(typeof(ServiceResponseViewModel<AccountViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<AccountViewModel>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] AccountViewModel accountViewModel)
        {
            ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = await _accountService.InsertAsync(accountViewModel);
            return StatusCode((int)serviceResponseViewModel.StatusCode, serviceResponseViewModel);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(ServiceResponseViewModel<AccountViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<AccountViewModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<AccountViewModel>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] AccountViewModel accountViewModel)
        {
            ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = await _accountService.UpdateAsync(accountViewModel);
            return StatusCode((int)serviceResponseViewModel.StatusCode, serviceResponseViewModel);
        }

        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(ServiceResponseViewModel<AccountViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<AccountViewModel>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById (int id)
        {
            ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = await _accountService.GetByIdAsync(id);
            return StatusCode((int)serviceResponseViewModel.StatusCode, serviceResponseViewModel);
        }
    }
}
