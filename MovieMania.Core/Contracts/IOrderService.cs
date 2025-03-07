﻿using MovieMania.Core.Models.Order;

namespace MovieMania.Core.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateAsync(OrderFormModel model, string userId, decimal cartTotalAmount);

        Task<bool> ExistsAsync(int orderId);

        Task<IEnumerable<OrderServiceModel>> AllAsync();

        Task<IEnumerable<OrderServiceModel>> AllOrdersByUserIdAsync(string userId);

        Task CreateOrderDetailsAsync(int cartId, int orderId);

        Task<OrderServiceModel> GetOrderServiceModelByUserIdAsync(int orderId, string userId);

        Task<OrderServiceModel> GetOrderServiceModelByOrderIdAsync(int orderId);
    }
}
