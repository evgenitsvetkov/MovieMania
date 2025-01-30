using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Core.Models.Cart
{
    public class CartItemServiceModel
    {
        public int CartItemId { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemTotal { get; set; }
    }
}
