using System.ComponentModel.DataAnnotations;
using static MovieMania.Infrastructure.Constants.DataConstants;
using static MovieMania.Core.Constants.MessageConstants;

namespace MovieMania.Core.Models.Movie
{
    public class MovieFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MovieTitleMaxLength,
            MinimumLength = MovieTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = null!;

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public IEnumerable<MovieGenreServiceModel> Genres { get; set; } 
            = new List<MovieGenreServiceModel>();

        [Required(ErrorMessage = RequiredMessage)]
        [Range(MovieReleaseDateMinLength,
            MovieReleaseDateMaxLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Release date")]
        public int ReleaseDate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), 
            MoviePriceMinLength,
            MoviePriceMaxLength,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MovieDescriptionMaxLength,
            MinimumLength = MovieDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;


        [Display(Name = "Director")]
        public int DirectorId { get; set; }

        public IEnumerable<MovieDirectorServiceModel> Directors { get; set; } 
            = new List<MovieDirectorServiceModel>();

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

    }
}
