using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Admin.User;
using static MovieMania.Core.Constants.AdministratorConstants;

namespace MovieMania.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;


        public UserController(
            IUserService _userService,
            IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }

        public async Task<IActionResult> All()
        {
            var model = memoryCache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

            if (model == null || model.Any() == false)
            {
                model = await userService.AllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                memoryCache.Set(UsersCacheKey, model, cacheOptions);
            }

            return View(model);
        }
    }
}
