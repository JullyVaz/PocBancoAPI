using Microsoft.AspNetCore.Mvc;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] TransferViewModel transferViewModel)
        {
            return Ok(await _transferService.Insert(transferViewModel));
        }
    }
}


