using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using LicenseGeneratorApplication.Command.Product;
using LicenseGeneratorApplication.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
