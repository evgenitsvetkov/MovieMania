using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Home;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Movies;

namespace MovieMania.Core.Services
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
            return await unitOfWork.AllReadOnly<Movie>()
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
