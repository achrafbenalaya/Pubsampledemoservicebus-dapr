using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pubsubapi.Models;
using pubsubapi.Persistqnce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pubsubapi.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderRepository _orderRepo;
        private readonly DaprClient _daprClient;

        public OrdersController(ILogger<OrdersController> logger, IOrderRepository orderRepo, DaprClient daprClient)
        {
            _logger = logger;
            _orderRepo = orderRepo;
            _daprClient = daprClient;
        }

        [Route("OrderReceived")]
        [HttpPost]
        [Topic("orderpubsub", "ordertopicevent")]
        public async Task<IActionResult> OrderReceived(Orders command)
        {
            if (command?.OrderId != null )
            {

                _logger.LogInformation($"Cloud event {command.OrderId} {command.UserEmail} received");

                var orderExists = await _orderRepo.GetOrderAsync(command.OrderId);
                if (orderExists == null)
                {
                    //register to DB
                    command.URD = System.DateTime.Now.ToString();
                    await _orderRepo.RegisterOrder(command);

                    //await _daprClient.PublishEventAsync("takeorderevent", "OrderRegisteredEvent", ore);
                    _logger.LogInformation($"For {command.OrderId}, OrderRegistered in db");
                }

                return Ok();

            }
            return BadRequest();

        }



    }
}
