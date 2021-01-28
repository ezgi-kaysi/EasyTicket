using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTicket.Services.Ordering.Messaging
{
    public interface IRabbitMQConsumer
    {
        void Start();
        void Stop();
    }
}
