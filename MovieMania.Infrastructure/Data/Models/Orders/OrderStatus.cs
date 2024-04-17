using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Infrastructure.Data.Models.Orders
{
    [Comment("Status of user's order")]
    public class OrderStatus
    {
        [Key]
        [Comment("Order status identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Status identifier")]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(OrderStatusNameMaxLength)]
        [Comment("Order status name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
