using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Infrastructure.Data.Models.Directors
{
    [Comment("Movie's director")]
    public class Director
    {
        [Key]
        [Comment("Director's identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Director's name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(BioMaxLength)]
        [Comment("Director's bio")]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [Comment("Director's birthday")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Comment("Director's profile picture url")]
        public string ImageUrl { get; set; } = string.Empty;

        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
    }
}
