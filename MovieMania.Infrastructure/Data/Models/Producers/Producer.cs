using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Infrastructure.Data.Models.Producers
{
    [Comment("Movie's producer")]
    public class Producer
    {
        [Key]
        [Comment("Producer's identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Producer's name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(BioMaxLength)]
        [Comment("Producer's bio")]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [Comment("Producer's birthday")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Comment("Producer's profile picture url")]
        public string ImageUrl { get; set; } = string.Empty;

        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
    }
}
