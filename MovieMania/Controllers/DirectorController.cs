using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Actor;
using MovieMania.Core.Models.Director;
using MovieMania.Core.Services;

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
        public async Task<IActionResult> Add()
        {
            var model = new DirectorFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DirectorFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            int newDirectorId = await directorService.CreateAsync(model);

            return RedirectToAction(nameof(Details), new { id = newDirectorId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await directorService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await directorService.GetDirectorFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DirectorFormModel model)
        {
            if (await directorService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await directorService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await directorService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var director = await directorService.DirectorsDetailsByIdAsync(id);

            var model = new DirectorDetailsViewModel()
            {
                Id = id,
                Name = director.Name,
                ImageUrl = director.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DirectorDetailsViewModel model)
        {
            if (await directorService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await directorService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
