using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;

namespace MovieMania.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        public async Task<IActionResult> All()
        {
            var model = await orderService.AllAsync();

            return View(model);
        }
    }
}
