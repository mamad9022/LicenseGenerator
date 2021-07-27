using LicenseGenerator.Application.Interface.License;
using LicenseGenerator.Common.Helper.Messages;
using LicenseGenerator.Common.Helper.Pagination;
using LicenseGeneratorApplication.Command.License;
using LicenseGeneratorApplication.Dtos.LicenseLog;
using LicenseGeneratorApplication.Dtos.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
