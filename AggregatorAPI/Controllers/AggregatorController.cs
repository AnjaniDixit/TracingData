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
            orderDetails.orders = await GetOrders();
            orderDetails.user = await GetUser();


            return orderDetails;
        }

        private async Task<User> GetUser()
        {
            var client = _factory.CreateClient("UserAPI");
            string urlcontainer = "http://userdataapi/user/1";
            //string urllocal = "http://localhost:5000/User/1";
            var requestMsg = new HttpRequestMessage(HttpMethod.Get, urlcontainer);

            var responseMsg = await client.SendAsync(requestMsg);

            var data = await responseMsg.Content.ReadAsStringAsync();


            var user = JsonConvert.DeserializeObject<User>(data);

            return user;

        }


        private async Task<IEnumerable<Order>> GetOrders()
        {
            var client = _factory.CreateClient("OrderAPI");

            string urlContainer = "http://orderapi/orders/1";
            //string urllocal = "http://localhost:5001/Orders/1";

            var requestMsg = new HttpRequestMessage(HttpMethod.Get, urlContainer);

            var responseMsg = await client.SendAsync(requestMsg);

            var data = await responseMsg.Content.ReadAsStringAsync();

            var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(data);

            return orders;
        }
    }
}
