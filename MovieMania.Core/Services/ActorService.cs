using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Enumerations;
using MovieMania.Core.Models.Actor;
using MovieMania.Core.Models.Movie;
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
            ActorSorting sorting = ActorSorting.Recently,
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

            actorsToShow = sorting switch
            {
                ActorSorting.Oldest => actorsToShow.OrderBy(m => m.Id),
                _ => actorsToShow.OrderByDescending(m => m.Id),
            };

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

        public async Task DeleteAsync(int actorId)
        {
            await unitOfWork.DeleteAsync<Actor>(actorId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(int actorId, ActorFormModel model)
        {
            var actor = await unitOfWork.GetByIdAsync<Actor>(actorId);

            if (actor != null)
            {
                actor.Name = model.Name;
                actor.Bio = model.Bio;
                actor.BirthDate = model.BirthDate;
                actor.ImageUrl = model.ImageUrl;

                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await unitOfWork.AllReadOnly<Actor>()
                .AnyAsync(a => a.Id == id);
        }

        public async Task<ActorFormModel?> GetActorFormModelByIdAsync(int id)
        {
            var actor = await unitOfWork.AllReadOnly<Actor>()
                .Where(a => a.Id == id)
                .Select(a => new ActorFormModel()
                {
                    Name = a.Name,
                    Bio = a.Bio,
                    BirthDate = a.BirthDate,
                    ImageUrl = a.ImageUrl
                })
                .FirstOrDefaultAsync();

            return actor;
        }

        public async Task<bool> ActorsExistsAsync(IEnumerable<int> actorIds)
        {
            var check = false;

            foreach (var actorId in actorIds)
            {
                check = await unitOfWork.AllReadOnly<Actor>()
                    .AnyAsync(a => a.Id == actorId);
            }

            return check;
        }

        public async Task<IEnumerable<MovieActorServiceModel>> AllActorsAsync()
        {
            return await unitOfWork.AllReadOnly<Actor>()
                .Select(d => new MovieActorServiceModel()
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

    }
}
