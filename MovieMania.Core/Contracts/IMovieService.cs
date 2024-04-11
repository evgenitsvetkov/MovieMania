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
    }
}
