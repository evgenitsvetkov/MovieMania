using MovieMania.Core.Enumerations;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;

namespace MovieMania.Core.Models.Movie
{
    public class AllMoviesQueryModel
    {
        public int MoviesPerPage { get; } = 6;

        public string Genre { get; set; } = null!;

        [Display(Name = "Search")]
        public string SearchTerm { get; set; } = null!;

        public MovieSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalMoviesCount { get; set; }

        public IEnumerable<string> Genres { get; set; } = null!;

        public IEnumerable<MovieServiceModel> Movies { get; set; } = new List<MovieServiceModel>();
    }
}
