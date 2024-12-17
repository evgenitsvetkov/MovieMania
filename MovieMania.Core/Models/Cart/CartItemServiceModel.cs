using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieMania.Core.Models.Cart
{
    public class CartItemServiceModel
    {
        [Key]
        [Comment("Cart item identifier")]
        public int CartItemId { get; set; }
        [Comment("Item's title")]        
        public string Title { get; set; } = string.Empty;

        [Comment("Item's image")]
        public string ImageUrl { get; set; } = string.Empty;
  
        [Comment("Item quantity")]
        public int Quantity { get; set; }

        [Comment("Total amount of item")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemTotal { get; set; }
    }
}
