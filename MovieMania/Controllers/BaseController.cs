using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieMania.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
