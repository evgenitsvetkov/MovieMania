using MovieMania.Infrastructure.Data.Models.Mappings;

namespace MovieMania.Core.Models.Movie
{
    public class MovieDetailsServiceModel : MovieServiceModel
    {
        public string Description { get; set; } = null!;

        public string Director { get; set; } = null!;

        public IEnumerable<MovieActorServiceModel> Actors { get; set; } = new List<MovieActorServiceModel>();
    }
}
