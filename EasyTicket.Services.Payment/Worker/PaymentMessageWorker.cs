﻿using EasyTicket.MessagingBus;
using EasyTicket.Services.Payment.Messages;
using EasyTicket.Services.Payment.Model;
using EasyTicket.Services.Payment.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EasyTicket.Services.Payment.Worker
{
    public class PaymentMessageWorker : RabMQServiceBase
    {
        private readonly ILogger<PaymentMessageWorker> _logger;
        private readonly IExternalGatewayPaymentService externalGatewayPaymentService;
        private readonly IMessageBus messageBus;
        private string _publishToQueueName;

        public PaymentMessageWorker(ILogger<PaymentMessageWorker> logger,
            IConfiguration configuration, IExternalGatewayPaymentService externalGatewayPaymentService, IMessageBus messageBus) : base(logger, configuration)
        {
            try
            {
                this.externalGatewayPaymentService = externalGatewayPaymentService;
                this.messageBus = messageBus;

                base.QueueName = configuration["RabbitMQ:OrderPaymentRequestMessageQueue"];
                _publishToQueueName = configuration["RabbitMQ:OrderPaymentUpdatedMessageQueue"];

                _logger = logger;

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

        public override async Task<bool> ProcessAsync(string messageBody)
        {
            OrderPaymentRequestMessage orderPaymentRequestMessage = JsonConvert.DeserializeObject<OrderPaymentRequestMessage>(messageBody);

            PaymentInfo paymentInfo = new PaymentInfo
            {
                CardNumber = orderPaymentRequestMessage.CardNumber,
                CardName = orderPaymentRequestMessage.CardName,
                CardExpiration = orderPaymentRequestMessage.CardExpiration,
                Total = orderPaymentRequestMessage.Total
            };

            var result = await externalGatewayPaymentService.PerformPayment(paymentInfo);

            //send payment result to order service via service bus
            OrderPaymentUpdateMessage orderPaymentUpdateMessage = new OrderPaymentUpdateMessage
            {
                PaymentSuccess = result,
                OrderId = orderPaymentRequestMessage.OrderId
            };

            try
            {
                await messageBus.PublishMessage(orderPaymentUpdateMessage, _publishToQueueName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            _logger.LogDebug($"{orderPaymentRequestMessage.OrderId}: ServiceBusListener received item.");
            _logger.LogDebug($"{orderPaymentRequestMessage.OrderId}:  ServiceBusListener processed item.");

            return result;
        }
    }
}
