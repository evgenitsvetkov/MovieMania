using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using static MovieMania.Infrastructure.Constants.DataConstants;
using static MovieMania.Core.Constants.MessageConstants;

namespace MovieMania.Core.Models.Movie
{
    public class MovieServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MovieTitleMaxLength,
            MinimumLength = MovieTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        public string Genre { get; set; } = null!;

        public IEnumerable<string> Genres { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(MovieReleaseDateMinLength,
            MovieReleaseDateMaxLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Release date")]
        public int ReleaseDate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            MoviePriceMinLength,
            MoviePriceMaxLength,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }
    }
}
