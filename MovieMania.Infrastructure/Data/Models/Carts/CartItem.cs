using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.Carts
{
    public class CartItem
    {
        [Key]
        [Comment("Cart item identifier")]
        public int CartItemId { get; set; }

        [Required]
        [Comment("Cart identifier")]
        public int CartId { get; set; }

        [Required]
        [Comment("Movie identifier")]
        public int MovieId { get; set; }

        [Required]
        [Comment("Item quantity")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Total amount of item")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemTotal { get; set; }
    }
}