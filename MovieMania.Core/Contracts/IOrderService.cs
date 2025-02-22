using MovieMania.Core.Models.Order;

namespace MovieMania.Core.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateAsync(OrderFormModel model, string userId, decimal cartTotalAmount);

        Task<bool> ExistsAsync(int orderId);

        Task<IEnumerable<OrderServiceModel>> AllAsync();

        Task<IEnumerable<OrderServiceModel>> AllUserOrdersAsync(string userId);

        Task CreateOrderDetailsAsync(int cartId, int orderId);

        Task<OrderServiceModel> GetOrderServiceModelAsync(int orderId, string userId);
    }
}
