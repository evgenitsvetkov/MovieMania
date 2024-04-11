using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Movie;

namespace MovieMania.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllMoviesQueryModel();

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new MovieDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new MovieFormModel()
            {
                Genres = await movieService.AllGenresAsync(),
                Directors = await movieService.AllDirectorsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormModel model)
        {
            if (await movieService.GenreExistsAsync(model.GenreId) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), "The genre does not exist!");
            }

            if (await movieService.DirectorExistsAsync(model.DirectorId) == false)
            {
                ModelState.AddModelError(nameof(model.DirectorId), "The director does not exist!");
            }

            if (ModelState.IsValid == false)
            {
                model.Genres = await movieService.AllGenresAsync();
                model.Directors = await movieService.AllDirectorsAsync();

                return View(model);
            }

            int newMovieId = await movieService.CreateAsync(model);


            return RedirectToAction(nameof(Details), new { id = newMovieId});
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
        public async Task<IActionResult> DeleteConfirm(MovieDetailsViewModel model)
        {

            return RedirectToAction(nameof(All));
        }
    }
}
