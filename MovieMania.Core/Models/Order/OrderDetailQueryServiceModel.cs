using MovieMania.Infrastructure.Data.Models.Orders;

namespace MovieMania.Core.Models.Order
{
    public class OrderDetailQueryServiceModel
    {
        public decimal TotalPrice { get; set; }

        public IEnumerable<OrderDetailServiceModel> OrderDetails { get; set; } = new List<OrderDetailServiceModel>();   
    }
}
