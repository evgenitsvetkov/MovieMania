using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.Orders
{
    [Comment("Details of user's orders")]
    public class OrderDetail
    {
        [Key]
        [Comment("Order detail identifier")]
        public int OrderDetailId { get; set; }

        [Required]
        [Comment("Order's identifier")]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        [Comment("Quantity of ordered movies")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Total amount of item")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemTotal { get; set; }

        [Required]
        [Comment("Movie's identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}
