using LicenseGenerator.Application.Interface.Product;
using LicenseGenerator.Common.Helper.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseGenerator.Application.Command.Product;
using LicenseGenerator.Application.Dtos.Product;
using LicenseGenerator.Common.Helper.Message;

namespace LicenseGenerator.Api.Controllers
{
    public class ProductsController: BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [ProducesResponseType(typeof(PagedList<ProductDto>), 200)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingOptions pagingOptions)
            => Ok(await _productService.GetPagingList(new PagingOptions
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Query = pagingOptions.Query
            }));


        [ProducesResponseType(typeof(List<ProductDto>), 200)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpGet("List")]
        public async Task<IActionResult> GetList()
           => Ok(await _productService.GetList());


        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(typeof(ApiMessage), 400)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpGet("{id}", Name = "GetProductDetail")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _productService.Get(id);
            if (result.Success == false)
                return result.ApiResult;
            return Ok(result);
        }


        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(ApiMessage), 400)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpPost]
        public async Task<IActionResult> Create(ProductAddCommand command)
        {
            var result = await _productService.Add(command);

            if (result.Success == false)
                return result.ApiResult;

            return CreatedAtAction(nameof(Get), new { result.Data }, result.Data);
        }
    }
}
