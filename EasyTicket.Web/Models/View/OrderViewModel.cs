using EasyTicket.Web.Models.Api;
using System.Collections.Generic;

namespace EasyTicket.Web.Models.View
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
