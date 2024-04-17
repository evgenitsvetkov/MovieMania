using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Director;

namespace MovieMania.Controllers
{
    public class DirectorController : BaseController
    {
        private readonly IDirectorService directorService;

        public DirectorController(IDirectorService _directorService)
        {
            directorService = _directorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllDirectorsQueryModel query)
        {
            var model = await directorService.AllAsync(
            query.SearchTerm,
            query.CurrentPage,
            query.DirectorsPerPage);

            query.TotalDirectorsCount = model.TotalDirectorsCount;
            query.Directors = model.Directors;

            return View(query);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await directorService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await directorService.DirectorsDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DirectorFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new DirectorFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DirectorFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(new DirectorDetailsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DirectorDetailsViewModel model)
        {

            return RedirectToAction(nameof(All));
        }
    }
}
