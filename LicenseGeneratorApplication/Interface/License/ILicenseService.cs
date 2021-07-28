using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using System.Threading.Tasks;
using LicenseGenerator.Application.Command.License;
using LicenseGenerator.Application.Dtos.LicenseLog;

namespace LicenseGenerator.Application.Interface.License
{
    public interface ILicenseService
    {
        Task<PagedList<LicenseLogDto>> GetPagingList(PagingOptions request);
        Task<Result<string>> Create(LicenseCreateCommand command);
    }
}
