using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts.Movie;
using MovieMania.Core.Models.Home;
using MovieMania.Infrastructure.Data.Common;

namespace MovieMania.Core.Services.Movie
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork unitOfWork;

        public MovieService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<IEnumerable<MovieIndexServiceModel>> LastFiveMovies()
        {
            return await unitOfWork.AllReadOnly<Infrastructure.Data.Models.Movies.Movie>()
                .OrderByDescending(m => m.Id)
                .Take(5)
                .Select(m => new MovieIndexServiceModel()
                {
                    Title = m.Title,
                    ImageURL = m.ImageURL
                })
                .ToListAsync();
        }   
    }
}
