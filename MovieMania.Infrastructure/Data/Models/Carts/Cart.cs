using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.CustomUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.Carts
{
    [Comment("User's shopping cart")]
    public class Cart
    {
        [Key]
        [Comment("Shopping cart's identifier")]
        public int CartId { get; set; }

        [Required]
        [Comment("User's identifier")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Required]
        [Comment("Total amount of all items in the cart")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}