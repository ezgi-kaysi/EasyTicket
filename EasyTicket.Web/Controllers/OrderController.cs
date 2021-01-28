using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTicket.Web.Models;
using EasyTicket.Web.Models.View;
using EasyTicket.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyTicket.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly Settings settings;

        public OrderController(Settings settings, IOrderService orderService)
        {
            this.settings = settings;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetOrdersForUser(settings.UserId);

            return View(new OrderViewModel { Orders = orders });
        }
    }
}
