using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseGenerator.Application.Command.Product;
using LicenseGenerator.Application.Dtos.Product;

namespace LicenseGenerator.Application.Interface.Product
{
    public interface IProductService
    {
        Task<PagedList<ProductDto>> GetPagingList(PagingOptions request);
        Task<List<LicenseGenerator.Model.Models.Product>> GetList();
        Task<Result<ProductDto>> Get(Guid id);
        Task<Result<Guid>> Add(ProductAddCommand command);
    }
}
