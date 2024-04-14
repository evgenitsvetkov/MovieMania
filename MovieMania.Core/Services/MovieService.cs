using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Enumerations;
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

        public async Task<MovieQueryServiceModel> AllAsync(
            string? genre = null, 
            string? searchTerm = null, 
            MovieSorting sorting = MovieSorting.Newest,
            int currentPage = 1, 
            int moviesPerPage = 1)
        {
            var moviesToShow = unitOfWork.AllReadOnly<Movie>();

            if (genre != null)
            {
                moviesToShow = moviesToShow
                    .Where(m => m.Genre.Name == genre);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                moviesToShow = moviesToShow
                    .Where(m => (m.Title.ToLower().Contains(normalizedSearchTerm) ||
                                m.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            moviesToShow = sorting switch
            { 
                MovieSorting.Price => moviesToShow.OrderBy(m => m.Price),
                _ => moviesToShow.OrderByDescending(m => m.Id),
            };

            var movies = await moviesToShow
                .Skip((currentPage - 1) * moviesPerPage)
                .Take(moviesPerPage)
                .ProjectToMovieServiceModel()
                .ToListAsync();

            int totalMovies = await moviesToShow.CountAsync();

            return new MovieQueryServiceModel()
            { 
                Movies = movies,
                TotalMoviesCount = totalMovies,
            };

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

        public async Task<IEnumerable<string>> AllGenresNamesAsync()
        {
            return await unitOfWork.AllReadOnly<Genre>()
                .Select(g => g.Name)
                .Distinct()
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

        public async Task<bool> ExistsAsync(int id)
        {
            return await unitOfWork.AllReadOnly<Movie>()
                .AnyAsync(m => m.Id == id);
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

        public async Task<MovieDetailsServiceModel> MoviesDetailsByIdAsync(int id)
        {
            return await unitOfWork.AllReadOnly<Movie>()
                .Where(m => m.Id == id)
                .Select(m => new MovieDetailsServiceModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre.Name,
                    ReleaseDate = m.ReleaseDate,
                    ImageUrl = m.ImageURL,
                    Price = m.Price,
                    Description = m.Description,
                    Director = m.Director.Name
                })
                .FirstAsync();
        }
    }
}
