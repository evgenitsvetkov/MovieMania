using MovieMania.Core.Models.Home;

namespace MovieMania.Core.Contracts.Movie
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieIndexServiceModel>> LastFiveMovies();
    }
}
