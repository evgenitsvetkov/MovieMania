using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Director;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Core.Constants.LogMessageConstants;

namespace MovieMania.Controllers
{
    public class DirectorController : BaseController
    {
        private readonly IDirectorService directorService;
        private readonly ILogger<DirectorController> logger;

        public DirectorController(IDirectorService _directorService, ILogger<DirectorController> _logger)
        {
            directorService = _directorService;
            logger = _logger;
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
                logger.LogWarning(DirectorNotFoundLogMessage, id);
                TempData[UserMessageError] = DirectorNotFoundUserMessage;

                return NotFound();
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
                logger.LogInformation(InvalidModelStateLogMessage, nameof(All), model);
                TempData[UserMessageError] = InvalidInputMessage;

                return View(model);
            }

            int newDirectorId = await directorService.CreateAsync(model);

            logger.LogInformation(DirectorCreatedLogMessage, newDirectorId);
            TempData[UserMessageSuccess] = DirectorAddedUserMessage;

            return RedirectToAction(nameof(Details), new { id = newDirectorId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await directorService.ExistsAsync(id) == false)
            {
                logger.LogWarning(DirectorNotFoundLogMessage, id);
                TempData[UserMessageError] = DirectorNotFoundUserMessage;

                return NotFound();
            }

            var model = await directorService.GetDirectorFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DirectorFormModel model)
        {
            if (await directorService.ExistsAsync(id) == false)
            {
                logger.LogWarning(DirectorNotFoundLogMessage, id);
                TempData[UserMessageError] = DirectorNotFoundUserMessage;

                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                logger.LogInformation(InvalidModelStateLogMessage, nameof(Edit), id);
                TempData[UserMessageError] = InvalidInputMessage;

                return View(model);
            }

            await directorService.EditAsync(id, model);

            logger.LogInformation(DirectorEditedLogMessage, id);
            TempData[UserMessageSuccess] = DirectorEditedUserMessage;

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await directorService.ExistsAsync(id) == false)
            {
                logger.LogWarning(DirectorNotFoundLogMessage, id);
                TempData[UserMessageError] = DirectorNotFoundUserMessage;

                return NotFound();
            }

            var director = await directorService.DirectorsDetailsByIdAsync(id);

            var model = new DirectorDetailsViewModel()
            {
                Id = id,
                Name = director.Name,
                ImageUrl = director.ImageUrl,
                Bio = director.Bio,
                BirthDate = director.BirthDate,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DirectorDetailsViewModel model)
        {
            if (await directorService.ExistsAsync(model.Id) == false)
            {
                logger.LogWarning(DirectorNotFoundLogMessage, model.Id);
                TempData[UserMessageError] = DirectorNotFoundUserMessage;

                return NotFound();
            }

            await directorService.DeleteAsync(model.Id);

            logger.LogInformation(DirectorDeletedLogMessage, model.Id);
            TempData[UserMessageSuccess] = DirectorDeletedUserMessage;

            return RedirectToAction(nameof(All));
        }
    }
}
