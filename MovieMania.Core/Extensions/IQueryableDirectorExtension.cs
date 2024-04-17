using MovieMania.Core.Models.Director;
using MovieMania.Infrastructure.Data.Models.Directors;

namespace System.Linq
{
    public static class IQueryableDirectorExtension
    {
        public static IQueryable<DirectorServiceModel> ProjectToDirectorServiceModel(this IQueryable<Director> directors)
        {
            return directors
                .Select(m => new DirectorServiceModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                });
        }
    }
}
