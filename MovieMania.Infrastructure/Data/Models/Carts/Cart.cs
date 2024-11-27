using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.Carts
{
    [Comment("User's shopping cart")]
    public class Cart
    {
        [Key]
        [Comment("Shopping cart's identifier")]
        public int RecordId { get; set; }

        [Comment("Cart item's identifier")]
        public string CartId { get; set; } = string.Empty;

        [Comment("Movie's identifier")]
        public int MovieId { get; set; }

        [Comment("Count of items")]
        public int Count { get; set; }

        [Comment("Date of cart's creation")]
        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;

    }
}
