using Microsoft.AspNetCore.Mvc;
using PocBancoAPI.Services;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;
using System.Net;

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
        [ProducesResponseType(typeof(ServiceResponseViewModel<TransferViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<TransferViewModel>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] TransferViewModel transferViewModel)
        {
            ServiceResponseViewModel<TransferViewModel> serviceResponseViewModel = await _transferService.InsertAsync(transferViewModel);
            return StatusCode((int)serviceResponseViewModel.StatusCode, serviceResponseViewModel);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(ServiceResponseViewModel<TransferViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<TransferViewModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<TransferViewModel>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] TransferViewModel transferViewModel)
        {
            if (transferViewModel.IdTransfer <= 0)
            {
                ServiceResponseViewModel<TransferViewModel> errorResponse = new ServiceResponseViewModel<TransferViewModel>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "O campo 'IdTransfer' é obrigatório para a atualização.",
                    HasData = false
                };

                return BadRequest(errorResponse);
            }

            ServiceResponseViewModel<TransferViewModel> serviceResponseViewModel = await _transferService.UpdateAsync(transferViewModel);
            return StatusCode((int)serviceResponseViewModel.StatusCode, serviceResponseViewModel);
        }

    }
}


       

    



