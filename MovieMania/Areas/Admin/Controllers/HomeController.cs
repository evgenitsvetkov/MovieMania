using Microsoft.AspNetCore.Mvc;

namespace MovieMania.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
