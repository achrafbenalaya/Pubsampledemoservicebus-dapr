using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pubsubmvcsample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace pubsubmvcsample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly Dapr.Client.DaprClient _DaprClient;

        public HomeController(ILogger<HomeController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _DaprClient = daprClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Orders orders)
        {

            _logger.LogInformation("adding orders..loading");
            _logger.LogInformation($"order UserEmail", orders.UserEmail);

            orders.OrderId = Guid.NewGuid();
            try
            {
                await _DaprClient.PublishEventAsync("orderpubsub", "ordertopicevent", orders);
                _logger.LogInformation("Publishing event: ordertopicevent, OrderId:  {orderId}", orders.OrderId);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "ERROR Publishing event: ordertopicevent: OrderId: {orderId}", orders.OrderId);
                throw;
            }

            ViewData["OrderId"] = orders.OrderId;
            return View("Thankyou");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
