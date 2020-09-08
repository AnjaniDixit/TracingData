using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AggregatorAPI.Models
{
    public class OrderDetails
    {
        public User user { get; set; }
        public IEnumerable<Order> orders { get; set; }
    }
}
