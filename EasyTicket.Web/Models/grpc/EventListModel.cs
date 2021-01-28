using EasyTicket.Grpc;
using System;
using System.Collections.Generic;

namespace EasyTicket.Web.Models.grpc

{
    public class EventListModel
    {     
        public IEnumerable<Event> Events { get; set; }
        public Guid SelectedCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int NumberOfItems { get; set; }
    }
}
