using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PocBancoAPI.Services;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] UserToInsertViewModel userToInsertViewModel)
        {
            ServiceResponseViewModel<UserViewModel> serviceResponseDTO = await _authService.Register(userToInsertViewModel);
            return Ok(serviceResponseDTO);
        }

        [HttpGet]
        [Route(nameof(Login))]
        public async Task<IActionResult> Login([FromQuery] UserLoginViewModel userLoginViewModel)
        {
            ServiceResponseViewModel<string> serviceResponseDTO = await _authService.Login(userLoginViewModel);
            return Ok(serviceResponseDTO);
        }
    }
}
