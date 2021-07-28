using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseGenerator.Application.Command.Customer;
using LicenseGenerator.Application.Dtos.Customer;

namespace LicenseGenerator.Application.Interface.Customer
{
    public interface ICustomerService
    {
        Task<PagedList<CustomerDto>> GetPagingList(PagingOptions request);
        Task<List<LicenseGenerator.Model.Models.Customer>> GetList();
        Task<Result<CustomerDto>> Add(CustomerAddCommand command);
    }
}
