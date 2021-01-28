using System;
using EasyTicket.Messages;

namespace EasyTicket.Services.Payment.Messages
{
    public class OrderPaymentUpdateMessage: BaseMessage
    {
        public Guid OrderId { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}
