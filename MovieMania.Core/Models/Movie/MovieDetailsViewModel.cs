namespace MovieMania.Core.Models.Movie
{
    public class MovieDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public IEnumerable<string> Genres { get; set; } = null!;

        public string ImageURL { get; set; } = null!;
    }
}
