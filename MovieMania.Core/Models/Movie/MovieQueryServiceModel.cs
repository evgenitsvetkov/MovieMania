namespace MovieMania.Core.Models.Movie
{
    public class MovieQueryServiceModel
    {
        public int TotalMoviesCount { get; set; }

        public IEnumerable<MovieServiceModel> Movies { get; set; } = new List<MovieServiceModel>();
    }
}
