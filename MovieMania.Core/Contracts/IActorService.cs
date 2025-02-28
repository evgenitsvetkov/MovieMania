using MovieMania.Core.Models.Actor;
using MovieMania.Core.Models.Movie;

namespace MovieMania.Core.Contracts
{
    public interface IActorService
    {
        Task<ActorQueryServiceModel> AllAsync(
            string? searchTerm = null,
            int currentPage = 1,
            int moviesPerPage = 1);

        Task<bool> ExistsAsync(int id);

        Task<ActorDetailsServiceModel> ActorsDetailsByIdAsync(int id);

        Task<int> CreateAsync(ActorFormModel model);

        Task<ActorFormModel?> GetActorFormModelByIdAsync(int id);

        Task EditAsync(int actorId, ActorFormModel model);

        Task DeleteAsync(int actorId);

        Task<IEnumerable<MovieActorServiceModel>> AllActorsAsync();

        Task<bool> ActorsExistsAsync(IEnumerable<int> actorIds);
    }
}
