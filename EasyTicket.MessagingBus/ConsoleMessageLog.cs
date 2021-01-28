using EasyTicket.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyTicket.MessagingBus
{
    public class ConsoleMessageLog : IMessageBus
    {
        public Task PublishMessage(BaseMessage message, string topicName)
        {
            Console.WriteLine("***************************");
            Console.WriteLine($"Topic: {topicName}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("***************************");

            return Task.FromResult<object>(null);
        }
    }
}