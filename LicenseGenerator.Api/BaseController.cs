using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LicenseGenerator.Api
{
    [Route("[Controller]")]
    [EnableCors]
    [ApiController]
    public class BaseController : Controller
    {
    }
}
