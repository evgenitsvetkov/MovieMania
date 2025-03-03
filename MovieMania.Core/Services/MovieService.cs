using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Enumerations;
using MovieMania.Core.Models.Home;
using MovieMania.Core.Models.Movie;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Actors;
using MovieMania.Infrastructure.Data.Models.Directors;
using MovieMania.Infrastructure.Data.Models.Movies;
using MovieMania.Infrastructure.Data.Models.Mappings;

namespace MovieMania.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IActorService actorService;
        private readonly IDirectorService directorService;

        public MovieService(
            IUnitOfWork _unitOfWork, 
            IActorService _actorService, 
            IDirectorService _directorService)
        {
            unitOfWork = _unitOfWork;
            actorService = _actorService;
            directorService = _directorService;
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
                MovieSorting.LowestPrice => moviesToShow.OrderBy(m => m.Price),
                MovieSorting.HighestPrice => moviesToShow.OrderByDescending(m => m.Price),
                MovieSorting.Oldest => moviesToShow.OrderBy(m => m.Id),
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
                ImageURL = model.ImageUrl,
                MoviesActors = model.ActorIds.Select(id => new MovieActor()
                {
                    ActorId = id,
                })
                .ToList(),
            };

            await unitOfWork.AddAsync(movie);
            await unitOfWork.SaveChangesAsync();

            return movie.Id;
        }

        public async Task DeleteAsync(int movieId)
        {
            await unitOfWork.DeleteAsync<Movie>(movieId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(int movieId, MovieFormModel model)
        {
            var movie = await unitOfWork.All<Movie>()
               .Include(m => m.MoviesActors)
               .FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie != null)
            {
                movie.Title = model.Title;
                movie.GenreId = model.GenreId;
                movie.ReleaseDate = model.ReleaseDate;
                movie.Price = model.Price;
                movie.Description = model.Description;
                movie.DirectorId = model.DirectorId;
                movie.ImageURL = model.ImageUrl;

                movie.MoviesActors = model.ActorIds.Select(a => new MovieActor()
                {
                    ActorId = a,
                    MovieId = movie.Id,
                }).ToList();

                await unitOfWork.SaveChangesAsync();
            }         
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

        public async Task<MovieFormModel?> GetMovieFormModelByIdAsync(int id)
        {
            var movie = await unitOfWork.AllReadOnly<Movie>()
                .Include(m => m.MoviesActors)
                .Where(m => m.Id == id)
                .Select(m => new MovieFormModel()
                {
                    Title = m.Title,
                    GenreId = m.GenreId,
                    ReleaseDate = m.ReleaseDate,
                    Price = m.Price,
                    Description = m.Description,
                    DirectorId = m.DirectorId,
                    ImageUrl = m.ImageURL,
                    ActorIds = m.MoviesActors.Select(ma => ma.ActorId).ToList(),
                })
                .FirstOrDefaultAsync();

            if (movie != null)
            {
                movie.Genres = await AllGenresAsync();
                movie.Directors = await directorService.AllDirectorsAsync();
                movie.Actors = await actorService.AllActorsAsync();
            }

            return movie;
        }

        public async Task<IEnumerable<MovieIndexServiceModel>> LastFiveMoviesAsync()
        {
            return await unitOfWork.AllReadOnly<Movie>()
                .OrderByDescending(m => m.Id)
                .Take(5)
                .Select(m => new MovieIndexServiceModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    ImageURL = m.ImageURL
                })
                .ToListAsync();
        }

        public async Task<MovieDetailsServiceModel> MoviesDetailsByIdAsync(int id)
        {
            return await unitOfWork.AllReadOnly<Movie>()
                .Include(m => m.MoviesActors)
                .ThenInclude(ma => ma.Actor)
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
                    Director = m.Director.Name,
                    Actors = m.MoviesActors.Select(m => new MovieActorServiceModel()
                    {
                        Name = m.Actor.Name,
                    })
                    .ToList(),
                })
                .FirstAsync();
        }
    }
}
