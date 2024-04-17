using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MovieMania.Core.Constants.RoleConstants;

namespace MovieMania.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
