using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("Orders/{id}")]
    public class OrderController : ControllerBase
    {
      

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            List<Order> orders = new List<Order>() { new Order { OrderId=1, OrderAmount=250, OrderDate="14-Apr-2020"},
                                                     new Order { OrderId=2, OrderAmount=350, OrderDate="15-Apr-2020"}
            };
            return orders;
        }
    }
}
