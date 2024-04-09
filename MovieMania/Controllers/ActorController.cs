using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Actor;

namespace MovieMania.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService actorService;

        public ActorController(IActorService _actorService)
        {
            actorService = _actorService;            
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllActorsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new ActorDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActorFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new ActorFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActorFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
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
