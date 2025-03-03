using MovieMania.Core.Enumerations;
using MovieMania.Core.Models.Director;
using MovieMania.Core.Models.Movie;

namespace MovieMania.Core.Contracts
{
    public interface IDirectorService
    {
        Task<DirectorQueryServiceModel> AllAsync(
            string? searchTerm = null,
            DirectorSorting sorting = DirectorSorting.Recently,
            int currentPage = 1,
            int directorsPerPage = 1);

        Task<bool> DirectorExistsAsync(int directorId);

        Task<DirectorDetailsServiceModel> DirectorsDetailsByIdAsync(int id);

        Task<int> CreateAsync(DirectorFormModel model);

        Task<DirectorFormModel?> GetDirectorFormModelByIdAsync(int id);

        Task EditAsync(int directorId, DirectorFormModel model);

        Task DeleteAsync(int directorId);

        Task<IEnumerable<MovieDirectorServiceModel>> AllDirectorsAsync();
    }
}
