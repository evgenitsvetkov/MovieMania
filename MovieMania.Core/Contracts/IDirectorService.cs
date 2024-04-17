using MovieMania.Core.Models.Director;

namespace MovieMania.Core.Contracts
{
    public interface IDirectorService
    {
        Task<DirectorQueryServiceModel> AllAsync(
            string? searchTerm = null,
            int currentPage = 1,
            int directorsPerPage = 1);

        Task<bool> ExistsAsync(int id);

        Task<DirectorDetailsServiceModel> DirectorsDetailsByIdAsync(int id);

        Task<int> CreateAsync(DirectorFormModel model);

        Task<DirectorFormModel?> GetDirectorFormModelByIdAsync(int id);

        Task EditAsync(int directorId, DirectorFormModel model);

        Task DeleteAsync(int directorId);
    }
}
