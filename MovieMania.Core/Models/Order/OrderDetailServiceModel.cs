using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Core.Models.Order
{
    public class OrderDetailServiceModel
    {
        [Key]
        [Comment("Order detail identifier")]
        public int OrderDetailId { get; set; }

        [Required]
        [Comment("Quantity of ordered movies")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Total amount of item")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemTotal { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
