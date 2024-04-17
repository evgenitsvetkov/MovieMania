namespace MovieMania.Core.Models.Movie
{
    public class MovieDetailsServiceModel : MovieServiceModel
    {
        public string Description { get; set; } = null!;

        public string Director { get; set; } = null!;

        public IEnumerable<string> Directors { get; set; } = null!;
    }
}
