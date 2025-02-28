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
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public IEnumerable<MovieGenreServiceModel> Genres { get; set; } 
            = new List<MovieGenreServiceModel>();

        [Display(Name = "Actors")]
        public IEnumerable<int> ActorIds { get; set; } = new List<int>();

        public IEnumerable<MovieActorServiceModel> Actors { get; set; } 
            = new List<MovieActorServiceModel>();


        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Release date")]
        public int ReleaseDate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), 
            MoviePriceMinLength,
            MoviePriceMaxLength,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = PriceMustBePositiveMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MovieDescriptionMaxLength,
            MinimumLength = MovieDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Director")]
        public int DirectorId { get; set; }

        public IEnumerable<MovieDirectorServiceModel> Directors { get; set; } 
            = new List<MovieDirectorServiceModel>();

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

    }
}
