using LicenseGenerator.Application.Interface.Customer;
using LicenseGenerator.Common.Helper.Messages;
using LicenseGenerator.Common.Helper.Pagination;
using LicenseGeneratorApplication.Command.Customer;
using LicenseGeneratorApplication.Dtos.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LicenseGenerator.Api.Controllers
{
    public class CustomerController: BaseController
    {
        private readonly ICustomerService _customerSerrvice;

        public CustomerController(ICustomerService customerSerrvice)
        {
            _customerSerrvice = customerSerrvice;
        }

        [ProducesResponseType(typeof(PagedList<CustomerDto>), 200)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingOptions pagingOptions)
            => Ok(await _customerSerrvice.GetPagingList(new PagingOptions
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Query = pagingOptions.Query
            }));


        [ProducesResponseType(typeof(List<CustomerDto>), 200)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpGet("List")]
        public async Task<IActionResult> GetList()
           => Ok(await _customerSerrvice.GetList());


        [ProducesResponseType(typeof(CustomerDto), 201)]
        [ProducesResponseType(typeof(ApiMessage), 400)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpPost]
        public async Task<IActionResult> Create(CustomerAddCommand command)
        {
            var result = await _customerSerrvice.Add(command);

            if (result.Success == false)
                return result.ApiResult;

            return CreatedAtAction(nameof(Get), new { result.Data.Id }, result.Data);
        }
    }
}
