using MovieMania.Core.Models.Home;

namespace MovieMania.Core.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieIndexServiceModel>> LastFiveMovies();
    }
}
