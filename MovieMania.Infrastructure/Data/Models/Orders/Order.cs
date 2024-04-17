using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.CustomUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.Orders
{
    [Comment("User's order")]
    public class Order
    {
        [Key]
        [Comment("Order's identifier")]
        public int Id { get; set; }

        [Comment("The date of order")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        [Required]
        [Comment("User's identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Order status identifier")]
        public int OrderStatusId { get; set; }

        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; } = null!;
                        
        public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();   

    }
}
