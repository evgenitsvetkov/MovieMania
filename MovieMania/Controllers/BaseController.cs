using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MovieMania.Core.Constants.RoleConstants;

namespace MovieMania.Controllers
{
    [Authorize(Roles = AdminRole)]
    public class BaseController : Controller
    {
    }
}
