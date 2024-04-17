using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.Carts
{
    [Comment("Detail of user's shopping cart")]
    public class CartDetail
    {
        [Key]
        [Comment("Cart detail's identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Quantity of movies in the cart")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Shopping cart's identifier")]
        public int ShoppingCartId { get; set; }

        [ForeignKey(nameof(ShoppingCartId))]
        public Cart Cart { get; set; } = null!;

        [Required]
        [Comment("Movie's identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}
