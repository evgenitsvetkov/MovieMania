using MovieMania.Core.Models.Movie;
using MovieMania.Infrastructure.Data.Models.Movies;

namespace System.Linq
{
    public static class IQueryableMovieExtension
    {
        public static IQueryable<MovieServiceModel> ProjectToMovieServiceModel(this IQueryable<Movie> movies)
        {
            return movies
                .Select(m => new MovieServiceModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre.Name,
                    ReleaseDate = m.ReleaseDate,
                    ImageUrl = m.ImageURL,
                    Price = m.Price
                });
        }
    }
}
