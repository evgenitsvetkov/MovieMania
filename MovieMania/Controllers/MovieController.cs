using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Movie;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Core.Constants.LogMessageConstants;

namespace MovieMania.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService movieService;
        private readonly ILogger<MovieController> logger;

        public MovieController(IMovieService _movieService, ILogger<MovieController> _logger)
        {
            movieService = _movieService;
            logger = _logger;
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
                logger.LogWarning(MovieNotFoundLogMessage, id);
                TempData[UserMessageError] = MovieNotFoundUserMessage;

                return NotFound();
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
                logger.LogWarning(AddGenreNotExistLogMessage, model.GenreId);
                ModelState.AddModelError(nameof(model.GenreId), GenreNotFoundUserMessage);
            }

            if (await movieService.DirectorExistsAsync(model.DirectorId) == false)
            {
                logger.LogWarning(AddDirectorNotExistLogMessage, model.DirectorId);
                ModelState.AddModelError(nameof(model.DirectorId), DirectorNotFoundUserMessage);
            }

            if (ModelState.IsValid == false)
            {
                logger.LogInformation(ModelNotValidLogMessage);

                model.Genres = await movieService.AllGenresAsync();
                model.Directors = await movieService.AllDirectorsAsync();

                TempData[UserMessageError] = InvalidInputMessage;

                return View(model);
            }

            int newMovieId = await movieService.CreateAsync(model);

            logger.LogInformation(MovieCreatedLogMessage, newMovieId);
            TempData[UserMessageSuccess] = MovieAddedUserMessage;

            return RedirectToAction(nameof(Details), new { id = newMovieId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await movieService.ExistsAsync(id) == false)
            {
                logger.LogWarning(MovieNotFoundLogMessage, id);
                TempData[UserMessageError] = MovieNotFoundUserMessage;

                return NotFound();
            }

            var model = await movieService.GetMovieFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieFormModel model)
        {
            if (await movieService.ExistsAsync(id) == false)
            {
                logger.LogWarning(MovieNotFoundLogMessage, id);
                TempData[UserMessageError] = MovieNotFoundUserMessage;

                return NotFound();
            }

            if (await movieService.GenreExistsAsync(model.GenreId) == false)
            {
                logger.LogWarning(EditGenreNotExistLogMessage, model.GenreId);
                ModelState.AddModelError(nameof(model.GenreId), GenreNotFoundUserMessage);
            }

            if (await movieService.DirectorExistsAsync(model.DirectorId) == false)
            {
                logger.LogWarning(EditDirectorNotExistLogMessage, model.DirectorId);
                ModelState.AddModelError(nameof(model.DirectorId), DirectorNotFoundUserMessage);
            }

            if (ModelState.IsValid == false)
            {
                logger.LogInformation(ModelNotValidLogMessage);
                TempData[UserMessageError] = InvalidInputMessage;

                model.Genres = await movieService.AllGenresAsync();
                model.Directors = await movieService.AllDirectorsAsync();
                
                return View(model);
            }

            await movieService.EditAsync(id, model);

            logger.LogInformation(MovieEditedLogMessage, id);
            TempData[UserMessageSuccess] = MovieEditedUserMessage;

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await movieService.ExistsAsync(id) == false)
            {
                logger.LogWarning(MovieNotFoundLogMessage, id);
                TempData[UserMessageError] = MovieNotFoundUserMessage;
                return NotFound();
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
                logger.LogWarning(MovieNotFoundLogMessage, model.Id);
                TempData[UserMessageError] = MovieNotFoundUserMessage;

                return NotFound();
            }

            await movieService.DeleteAsync(model.Id);

            logger.LogInformation(MovieDeletedLogMessage, model.Id);
            TempData[UserMessageSuccess] = MovieDeletedUserMessage;

            return RedirectToAction(nameof(All));
        }
    }
}
