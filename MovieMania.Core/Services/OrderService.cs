using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Order;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Carts;
using MovieMania.Infrastructure.Data.Models.Orders;

namespace MovieMania.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork _unitofWork)
        {
            unitOfWork = _unitofWork;
        }

        public async Task<int> CreateAsync(OrderFormModel model, string userId, decimal cartTotalAmount)
        {
            Order order = new Order()
            {
                Email = model.Email,
                Address = model.Address,
                OrderDate = DateTime.Now,
                TotalAmount = cartTotalAmount,
                City = model.City,
                Country = model.Country,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                PostalCode = model.PostalCode,
                State = model.State,
                UserId = userId,
                OrderDetails = new List<OrderDetail>()
            };

            await unitOfWork.AddAsync(order);
            await unitOfWork.SaveChangesAsync();

            return order.OrderId;
        }

        public async Task CreateOrderDetailsAsync(int cartId, int orderId)
        {
            var cartItems = await unitOfWork.AllReadOnly<CartItem>()
                .Where(ci => ci.CartId == cartId)
                .ToListAsync();

            foreach (var item in cartItems)
            {
                var model = new OrderDetail()
                {
                    ItemTotal = item.ItemTotal,
                    MovieId = item.MovieId,
                    Quantity = item.Quantity,
                    OrderId = orderId
                };
                await unitOfWork.AddAsync(model);
            }

            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int orderId)
        {
            return await unitOfWork.AllReadOnly<Order>()
                .AnyAsync(o => o.OrderId == orderId);
        }
        public async Task<IEnumerable<OrderServiceModel>> AllAsync()
        {
            return await unitOfWork.AllReadOnly<Order>()
                .Select(o => new OrderServiceModel()
                {
                    OrderId = o.OrderId,
                    UserId = o.UserId,
                    Email = o.Email,
                    Address = o.Address,
                    City = o.City,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    State = o.State,
                    Country = o.Country,
                    Phone = o.Phone,
                    PostalCode = o.PostalCode,
                    TotalAmount = o.TotalAmount,
                })
                .ToListAsync();
        }

        public async Task<OrderServiceModel> GetOrderServiceModelAsync(int orderId, string userId)
        {
            return await unitOfWork.AllReadOnly<Order>()
                .Where(o => o.OrderId == orderId && o.UserId == userId)
                .Select(o => new OrderServiceModel()
                {
                    OrderId = o.OrderId,
                    UserId = userId,
                    Email = o.Email,
                    Address = o.Address,
                    City = o.City,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    State = o.State,
                    Country = o.Country,
                    Phone = o.Phone,
                    PostalCode = o.PostalCode,
                    TotalAmount = o.TotalAmount,
                    OrderDetails = o.OrderDetails.Select(od => new OrderDetailServiceModel()
                    {
                        ImageUrl = od.Movie.ImageURL,
                        ItemTotal = od.ItemTotal,
                        Quantity = od.Quantity,
                        Title = od.Movie.Title
                    })
                    .ToList(),
                })
                .FirstAsync();
        }
    }
}
