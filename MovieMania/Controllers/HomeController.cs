using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Models;
using System.Diagnostics;

namespace MovieMania.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService movieService;

        public HomeController(
            ILogger<HomeController> logger,
            IMovieService _movieService)
        {
            _logger = logger;
            movieService = _movieService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await movieService.LastFiveMovies(); 

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
