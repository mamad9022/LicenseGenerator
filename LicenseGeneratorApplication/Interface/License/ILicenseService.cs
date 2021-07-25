using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using LicenseGeneratorApplication.Command.License;
using LicenseGeneratorApplication.Dtos.LicenseLog;
using System.Threading.Tasks;

namespace LicenseGenerator.Application.Interface.License
{
    public interface ILicenseService
    {
        Task<PagedList<LicenseLogDto>> GetPagingList(PagingOptions request);
        Task<Result<string>> Create(LicenseCreateCommand command);
    }
}
