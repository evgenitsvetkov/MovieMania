using MovieMania.Core.Enumerations;
using MovieMania.Core.Models.Home;
using MovieMania.Core.Models.Movie;

namespace MovieMania.Core.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieIndexServiceModel>> LastFiveMoviesAsync();

        Task<IEnumerable<MovieGenreServiceModel>> AllGenresAsync();

        Task<IEnumerable<MovieDirectorServiceModel>> AllDirectorsAsync();

        Task<bool> GenreExistsAsync(int genreId);

        Task<bool> DirectorExistsAsync(int directorId);

        Task<int> CreateAsync(MovieFormModel model);

        Task<MovieQueryServiceModel> AllAsync(
            string? genre = null,
            string searchTerm = null,
            MovieSorting sorting = MovieSorting.Newest,
            int currentPage = 1,
            int moviesPerPage = 1);

        Task<IEnumerable<string>> AllGenresNamesAsync();
    }
}
