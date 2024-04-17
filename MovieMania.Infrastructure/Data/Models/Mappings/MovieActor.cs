using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Actors;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.Mappings
{
    [Comment("Movie and actor mapping")]
    public class MovieActor
    {
        [Required]
        [Comment("Movie's identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;

        [Required]
        [Comment("Actor's identifier")]
        public int ActorId { get; set; }

        [ForeignKey(nameof(ActorId))]
        public Actor Actor { get; set; } = null!;
    }
}
