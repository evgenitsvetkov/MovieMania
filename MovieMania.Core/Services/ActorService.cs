using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Actor;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Actors;

namespace MovieMania.Core.Services
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork unitOfWork;

        public ActorService(IUnitOfWork _unitOfWork)
        {
                unitOfWork = _unitOfWork;
        }

        public async Task<ActorDetailsServiceModel> ActorsDetailsByIdAsync(int id)
        {
            return await unitOfWork.AllReadOnly<Actor>()
                .Where(a => a.Id == id)
                .Select(a => new ActorDetailsServiceModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Bio = a.Bio,
                    BirthDate = a.BirthDate,
                    ImageUrl = a.ImageUrl
                })
                .FirstAsync();
        }

        public async Task<ActorQueryServiceModel> AllAsync(
            string? searchTerm = null,
            int currentPage = 1,
            int actorsPerPage = 1)
        {
            var actorsToShow = unitOfWork.AllReadOnly<Actor>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                actorsToShow = actorsToShow
                    .Where(m => (m.Name.ToLower().Contains(normalizedSearchTerm) ||
                                m.Bio.ToLower().Contains(normalizedSearchTerm)));
            }

            var actors = await actorsToShow
                .Skip((currentPage - 1) * actorsPerPage)
                .Take(actorsPerPage)
                .ProjectToActorServiceModel()
                .ToListAsync();

            int totalActors = await actorsToShow.CountAsync();

            return new ActorQueryServiceModel()
            {
                Actors = actors,
                TotalActorsCount = totalActors,
            };

        }

        public async Task<int> CreateAsync(ActorFormModel model)
        {
            Actor actor = new Actor()
            {
                Name = model.Name,
                Bio = model.Bio,
                BirthDate = model.BirthDate,
                ImageUrl = model.ImageUrl
            };

            await unitOfWork.AddAsync(actor);
            await unitOfWork.SaveChangesAsync();

            return actor.Id;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await unitOfWork.AllReadOnly<Actor>()
                .AnyAsync(a => a.Id == id);
        }
    }
}
