using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.ShoppingCarts
{
    [Comment("User's shopping cart")]
    public class Cart
    {
        [Key]
        [Comment("Shopping cart identifier")]
        public int Id { get; set; }

        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [Comment("Movie's identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;

        [Comment("Quantity of movies")]
        public int Quantity { get; set; }

        [Comment("Shopping cart's date of creation")]
        public DateTime DateCreated { get; set; } 

    }
}
