using LicenseGenerator.Application.Interface.License;
using LicenseGenerator.Common.Helper.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LicenseGenerator.Application.Command.License;
using LicenseGenerator.Application.Dtos.LicenseLog;
using LicenseGenerator.Application.Dtos.Product;
using LicenseGenerator.Common.Helper.Message;

namespace LicenseGenerator.Api.Controllers
{
    public class LicenseController : BaseController
    {
        private readonly ILicenseService _licenseService;

        public LicenseController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        [ProducesResponseType(typeof(PagedList<LicenseLogDto>), 200)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingOptions pagingOptions)
            => Ok(await _licenseService.GetPagingList(new PagingOptions
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Query = pagingOptions.Query
            }));


        [ProducesResponseType(typeof(ProductDto), 201)]
        [ProducesResponseType(typeof(ApiMessage), 400)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpPost]
        public async Task<IActionResult> Create(LicenseCreateCommand command)
        {
            var result = await _licenseService.Create(command);

            if (result.Success == false)
                return result.ApiResult;

            return CreatedAtAction(nameof(Get), new { result.Data }, result);
        }
    }
}
