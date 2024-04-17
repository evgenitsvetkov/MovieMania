using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MovieMania.Core.Constants.AdministratorConstants;

namespace MovieMania.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
