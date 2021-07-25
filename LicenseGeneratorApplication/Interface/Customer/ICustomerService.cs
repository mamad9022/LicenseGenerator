using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using LicenseGeneratorApplication.Command.Customer;
using LicenseGeneratorApplication.Dtos.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LicenseGenerator.Application.Interface.Customer
{
    public interface ICustomerService
    {
        Task<PagedList<CustomerDto>> GetPagingList(PagingOptions request);
        Task<List<LicenseGenerator.Model.Models.Customer>> GetList();
        Task<Result<CustomerDto>> Add(CustomerAddCommand command);
    }
}
