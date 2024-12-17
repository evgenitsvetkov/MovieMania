using MovieMania.Core.Models.Order;

namespace MovieMania.Core.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateAsync(OrderFormModel model, string userId);

        Task<bool> ExistsAsync(int id);

        Task<IEnumerable<OrderServiceModel>> AllAsync();

        Task CreateOrderDetailsAsync(int cartId, int orderId);

        Task<OrderServiceModel> GetOrderServiceModelAsync(int id, string userId);
    }
}
