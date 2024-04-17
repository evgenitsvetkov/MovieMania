using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Infrastructure.Data.Models.Movies
{
    [Comment("Movie's genre")]
    public class Genre
    {
        [Key]
        [Comment("Genre's identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        [Comment("Genre's name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Movie> Movies { get; set;} = new List<Movie>();
    }
}
