using MovieMania.Core.Models.Actor;

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
    }
}
