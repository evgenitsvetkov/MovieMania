using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Home;
using MovieMania.Core.Models.Movie;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Directors;
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

        public async Task<IEnumerable<MovieDirectorServiceModel>> AllDirectorsAsync()
        {
            return await unitOfWork.AllReadOnly<Director>()
                .Select(d => new MovieDirectorServiceModel()
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieGenreServiceModel>> AllGenresAsync()
        {
            return await unitOfWork.AllReadOnly<Genre>()
                .Select(g => new MovieGenreServiceModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }

        public async Task<int> CreateAsync(MovieFormModel model)
        {
            Movie movie = new Movie()
            {
                Title = model.Title,
                GenreId = model.GenreId,
                ReleaseDate = model.ReleaseDate,
                Price = model.Price,
                Description = model.Description,
                DirectorId = model.DirectorId,
                ImageURL = model.ImageUrl
            };

            await unitOfWork.AddAsync(movie);
            await unitOfWork.SaveChangesAsync();

            return movie.Id;
        }

        public async Task<bool> DirectorExistsAsync(int directorId)
        {
            return await unitOfWork.AllReadOnly<Director>()
                .AnyAsync(d => d.Id == directorId);
        }

        public async Task<bool> GenreExistsAsync(int genreId)
        {
            return await unitOfWork.AllReadOnly<Genre>()
                .AnyAsync(g => g.Id == genreId);
        }

        public async Task<IEnumerable<MovieIndexServiceModel>> LastFiveMoviesAsync()
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
