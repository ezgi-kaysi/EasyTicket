using EasyTicket.Messages;
using System.Threading.Tasks;

namespace EasyTicket.MessagingBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}
