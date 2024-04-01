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
        public int Id { get; set; }

        [Required]
        [Comment("Quantity of ordered movies")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Price for single movie")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Comment("Order's identifier")]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        [Comment("Movie's identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}
