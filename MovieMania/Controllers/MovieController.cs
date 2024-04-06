using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Models.House;

namespace MovieMania.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllMoviesQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new MovieDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new MovieFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(new MovieDetailsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MovieDetailsViewModel model)
        {

            return RedirectToAction(nameof(All));
        }
    }
}
