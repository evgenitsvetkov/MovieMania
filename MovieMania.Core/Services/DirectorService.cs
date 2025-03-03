using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Enumerations;
using MovieMania.Core.Models.Director;
using MovieMania.Core.Models.Movie;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Directors;

namespace MovieMania.Core.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IUnitOfWork unitOfWork;

        public DirectorService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<DirectorQueryServiceModel> AllAsync(
            string? searchTerm = null,
            DirectorSorting sorting = DirectorSorting.Recently,
            int currentPage = 1, 
            int directorsPerPage = 1)
        {
            var directorsToShow = unitOfWork.AllReadOnly<Director>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                directorsToShow = directorsToShow
                    .Where(m => (m.Name.ToLower().Contains(normalizedSearchTerm) ||
                                m.Bio.ToLower().Contains(normalizedSearchTerm)));
            }

            directorsToShow = sorting switch
            {
                DirectorSorting.Oldest => directorsToShow.OrderBy(m => m.Id),
                _ => directorsToShow.OrderByDescending(m => m.Id),
            };

            var directors = await directorsToShow
                .Skip((currentPage - 1) * directorsPerPage)
                .Take(directorsPerPage)
                .ProjectToDirectorServiceModel()
                .ToListAsync();

            int totalDirectors = await directorsToShow.CountAsync();

            return new DirectorQueryServiceModel()
            {
                Directors = directors,
                TotalDirectorsCount = totalDirectors,
            };
        }

        public async Task<int> CreateAsync(DirectorFormModel model)
        {
            Director director = new Director()
            {
                Name = model.Name,
                Bio = model.Bio,
                BirthDate = model.BirthDate,
                ImageUrl = model.ImageUrl
            };

            await unitOfWork.AddAsync(director);
            await unitOfWork.SaveChangesAsync();

            return director.Id;
        }

        public async Task DeleteAsync(int directorId)
        {
            await unitOfWork.DeleteAsync<Director>(directorId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<DirectorDetailsServiceModel> DirectorsDetailsByIdAsync(int id)
        {
            return await unitOfWork.AllReadOnly<Director>()
                .Where(d => d.Id == id)
                .Select(d => new DirectorDetailsServiceModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Bio = d.Bio,
                    BirthDate = d.BirthDate,
                    ImageUrl = d.ImageUrl
                })
                .FirstAsync();
        }

        public async Task EditAsync(int directorId, DirectorFormModel model)
        {
            var director = await unitOfWork.GetByIdAsync<Director>(directorId);

            if (director != null)
            {
                director.Name = model.Name;
                director.Bio = model.Bio;
                director.BirthDate = model.BirthDate;
                director.ImageUrl = model.ImageUrl;

                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<bool> DirectorExistsAsync(int directorId)
        {
            return await unitOfWork.AllReadOnly<Director>()
                .AnyAsync(d => d.Id == directorId);
        }

        public async Task<DirectorFormModel?> GetDirectorFormModelByIdAsync(int id)
        {
            var director = await unitOfWork.AllReadOnly<Director>()
                .Where(d => d.Id == id)
                .Select(d => new DirectorFormModel()
                {
                    Name = d.Name,
                    Bio = d.Bio,
                    BirthDate = d.BirthDate,
                    ImageUrl = d.ImageUrl
                })
                .FirstOrDefaultAsync();

            return director;
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
    }
}
