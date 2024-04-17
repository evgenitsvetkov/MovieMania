using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Mappings;
using System.ComponentModel.DataAnnotations;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Infrastructure.Data.Models.Actors
{
    [Comment("Movie's actor")]
    public class Actor
    {
        [Key]
        [Comment("Actor's identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Actor's name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(BioMaxLength)]
        [Comment("Actor's bio")]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [Comment("Actor's birthdate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Comment("Actor's profile picture url")]
        public string ImageUrl { get; set; } = string.Empty;

        public IEnumerable<MovieActor> MoviesActors { get; set; } = new List<MovieActor>();
    }
}
