using Microsoft.AspNetCore.Mvc;
using PocBancoAPI.Services;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;
using System.Collections.Generic;
using System.Net;

namespace PocBancoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialOperationController : ControllerBase
    {
        private readonly IFinancialOperationService _financialOperationService;
        public FinancialOperationController(IFinancialOperationService financialOperationService)
        {
            _financialOperationService = financialOperationService;
        }

        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(typeof(ServiceResponseViewModel<FinancialOperationViewModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<FinancialOperationViewModel>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] FinancialOperationViewModel financialOperationViewModel)
        {
            ServiceResponseViewModel<FinancialOperationViewModel> serviceResponseViewModel = await _financialOperationService.InsertAsync(financialOperationViewModel);
            return StatusCode((int)serviceResponseViewModel.StatusCode, serviceResponseViewModel);
        }

        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(ServiceResponseViewModel<FinancialOperationViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<FinancialOperationViewModel>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<FinancialOperationViewModel>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            ServiceResponseViewModel<FinancialOperationViewModel> serviceResponseViewModel = await _financialOperationService.GetByIdAsync(id);
            return StatusCode((int)serviceResponseViewModel.StatusCode, serviceResponseViewModel);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(ServiceResponseViewModel<List<FinancialOperationViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<List<FinancialOperationViewModel>>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceResponseViewModel<List<FinancialOperationViewModel>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] FinancialOperationFilter financialOperationFilter)
        {
            ServiceResponseViewModel< List< FinancialOperationViewModel >> serviceResponseViewModel = await _financialOperationService.GetAllAsync(financialOperationFilter);
            return StatusCode((int)serviceResponseViewModel.StatusCode, serviceResponseViewModel);
        }
    }
}


       

    



