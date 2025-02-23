using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Core.Constants.LogMessageConstants;

namespace MovieMania.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService _orderService, ILogger<OrderController> _logger)
        {
            orderService = _orderService;
            logger = _logger;

        }

        public async Task<IActionResult> All()
        {
            var model = await orderService.AllAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {

            if (!await orderService.ExistsAsync(Id))
            {
                logger.LogWarning(AdminOrderNotExistLogMessage, Id);
                TempData[UserMessageError] = OrderNotFoundMessage;

                return NotFound();
            }

            var order = await orderService.GetOrderServiceModelAsync(Id);

            return View(order);
        }
    }
}
