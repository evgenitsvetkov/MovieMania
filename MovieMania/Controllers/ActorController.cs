using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Actor;
using MovieMania.Core.Models.Movie;
using MovieMania.Core.Services;

namespace MovieMania.Controllers
{
    public class ActorController : BaseController
    {
        private readonly IActorService actorService;

        public ActorController(IActorService _actorService)
        {
            actorService = _actorService;            
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllActorsQueryModel query)
        {
            var model = await actorService.AllAsync(
                query.SearchTerm,
                query.CurrentPage,
                query.ActorsPerPage);

            query.TotalActorsCount = model.TotalActorsCount;
            query.Actors = model.Actors;
            
            return View(query);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await actorService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await actorService.ActorsDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ActorFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActorFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            int newActorId = await actorService.CreateAsync(model);

            return RedirectToAction(nameof(Details), new { id = newActorId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await actorService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await actorService.GetActorFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActorFormModel model)
        {
            if (await actorService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await actorService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(new ActorDetailsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ActorDetailsViewModel model)
        {

            return RedirectToAction(nameof(All));
        }
    }
}
