using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Actor;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Core.Constants.LogMessageConstants;

namespace MovieMania.Controllers
{
    public class ActorController : BaseController
    {
        private readonly IActorService actorService;
        private readonly ILogger<ActorController> logger;

        public ActorController(IActorService _actorService, ILogger<ActorController> _logger)
        {
            actorService = _actorService;
            logger = _logger;
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
                logger.LogWarning(ActorNotFoundLogMessage, id);
                TempData[UserMessageError] = ActorNotFoundLogMessage;

                return NotFound();
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
                logger.LogInformation(ModelNotValidLogMessage);
                TempData[UserMessageError] = InvalidInputMessage;

                return View(model);
            }

            int newActorId = await actorService.CreateAsync(model);

            logger.LogInformation(ActorCreatedLogMessage, newActorId);
            TempData[UserMessageSuccess] = ActorAddedUserMessage;

            return RedirectToAction(nameof(Details), new { id = newActorId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await actorService.ExistsAsync(id) == false)
            {
                logger.LogWarning(ActorNotFoundLogMessage, id);
                TempData[UserMessageError] = ActorNotFoundUserMessage;

                return NotFound();
            }

            var model = await actorService.GetActorFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActorFormModel model)
        {
            if (await actorService.ExistsAsync(id) == false)
            {
                logger.LogWarning(ActorNotFoundLogMessage, id);
                TempData[UserMessageError] = ActorNotFoundUserMessage;

                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                logger.LogInformation(ModelNotValidLogMessage);
                TempData[UserMessageError] = InvalidInputMessage;

                return View(model);
            }

            await actorService.EditAsync(id, model);

            logger.LogInformation(ActorEditedLogMessage, id);
            TempData[UserMessageSuccess] = ActorEditedUserMessage;

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await actorService.ExistsAsync(id) == false)
            {
                logger.LogWarning(ActorNotFoundLogMessage, id);
                TempData[UserMessageError] = ActorNotFoundUserMessage;

                return NotFound();
            }

            var actor = await actorService.ActorsDetailsByIdAsync(id);

            var model = new ActorDetailsViewModel()
            {
                Id = id,
                Name = actor.Name,
                ImageUrl = actor.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ActorDetailsViewModel model)
        {
            if (await actorService.ExistsAsync(model.Id) == false)
            {
                logger.LogWarning(ActorNotFoundLogMessage, model.Id);
                TempData[UserMessageError] = ActorNotFoundUserMessage;

                return NotFound();
            }

            await actorService.DeleteAsync(model.Id);

            logger.LogInformation(ActorDeletedLogMessage, model.Id);
            TempData[UserMessageSuccess] = ActorDeletedUserMessage;

            return RedirectToAction(nameof(All));
        }
    }
}
