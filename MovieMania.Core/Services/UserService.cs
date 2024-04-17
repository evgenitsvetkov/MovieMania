using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Admin.User;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.CustomUser;

namespace MovieMania.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork _unitOfWork)
        {
                unitOfWork = _unitOfWork;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await unitOfWork.AllReadOnly<ApplicationUser>()
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
                })
               .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;

            var user = await unitOfWork
                .GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
