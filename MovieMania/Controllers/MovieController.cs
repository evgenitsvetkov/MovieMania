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
        public async Task<IActionResult> All([FromQuery]AllMoviesQueryModel query)
        {
            var model = await movieService.AllAsync(
                query.Genre,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.MoviesPerPage);

            query.TotalMoviesCount = model.TotalMoviesCount;
            query.Movies = model.Movies;
            query.Genres = await movieService.AllGenresNamesAsync();

            return View(query);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await movieService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await movieService.MoviesDetailsByIdAsync(id);

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
                ModelState.AddModelError(nameof(model.GenreId), "Genre does not exist!");
            }

            if (await movieService.DirectorExistsAsync(model.DirectorId) == false)
            {
                ModelState.AddModelError(nameof(model.DirectorId), "Director does not exist!");
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
            if (await movieService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await movieService.GetMovieFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieFormModel model)
        {
            if (await movieService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await movieService.GenreExistsAsync(model.GenreId) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), "Genre does not exist!");
            }

            if (await movieService.DirectorExistsAsync(model.DirectorId) == false)
            {
                ModelState.AddModelError(nameof(model.DirectorId), "Director does not exist!");
            }

            if (ModelState.IsValid == false)
            {
                model.Genres = await movieService.AllGenresAsync();
                model.Directors = await movieService.AllDirectorsAsync();
                
                return View(model);
            }

            await movieService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await movieService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var movie = await movieService.MoviesDetailsByIdAsync(id);

            var model = new MovieDetailsViewModel()
            {
                Id = id,
                Title = movie.Title,
                Genre = movie.Genre,
                ImageURL = movie.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MovieDetailsViewModel model)
        {
            if (await movieService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await movieService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
