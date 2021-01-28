using EasyTicket.MessagingBus;
using EasyTicket.Services.Ordering.Repositories;
using Microsoft.Extensions.Configuration;

namespace EasyTicket.Services.Ordering.Messaging
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        private CheckoutUpdateConsumer checkoutConsumer;
        private PaymentUpdateConsumer paymentConsumer;

        public RabbitMQConsumer(IConfiguration configuration, IMessageBus messageBus, OrderRepository orderRepository)
        {
            checkoutConsumer = new CheckoutUpdateConsumer(configuration, messageBus, orderRepository);
            paymentConsumer = new PaymentUpdateConsumer(configuration, messageBus, orderRepository);
        }

        public void Start()
        {
            checkoutConsumer.RegisterConsumer();
            paymentConsumer.RegisterConsumerAsync();
        }

        public void Stop()
        {
            checkoutConsumer.Stop();
            paymentConsumer.Stop();
        }
    }
}
