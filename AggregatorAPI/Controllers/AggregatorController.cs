using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AggregatorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AggregatorAPI.Controllers
{
    [ApiController]
    [Route("orderdetails/{id}")]
    public class AggregatorController : ControllerBase
    {


        private readonly ILogger<AggregatorController> _logger;
        private readonly IHttpClientFactory _factory;

        public AggregatorController(ILogger<AggregatorController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        [HttpGet]
        public async Task<OrderDetails> GetAsync()

        {
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.user = await GetUser();
            orderDetails.orders = await GetOrders();
            return orderDetails;
        }

        private async Task<User> GetUser()
        {
            var client = _factory.CreateClient("UserAPI");

            var requestMsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/User/1");

            var responseMsg = await client.SendAsync(requestMsg);

            var data = await responseMsg.Content.ReadAsStringAsync();


            var user = JsonConvert.DeserializeObject<User>(data);

            return user;

        }


        private async Task<IEnumerable<Order>> GetOrders()
        {
            var client = _factory.CreateClient("OrderAPI");

            var requestMsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5001/Orders/1");

            var responseMsg = await client.SendAsync(requestMsg);

            var data = await responseMsg.Content.ReadAsStringAsync();

            var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(data);

            return orders;
        }
    }
}
