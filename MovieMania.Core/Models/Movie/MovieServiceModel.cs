using System.ComponentModel.DataAnnotations;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Core.Models.Movie
{
    public class MovieServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MovieTitleMaxLength,
            MinimumLength = MovieTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Release date")]
        public int ReleaseDate { get; set; } 

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            MoviePriceMinLength,
            MoviePriceMaxLength,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = PriceMustBePositiveMessage)]
        public decimal Price { get; set; }
    }
}
