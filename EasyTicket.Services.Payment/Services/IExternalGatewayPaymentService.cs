using EasyTicket.Services.Payment.Model;
using System.Threading.Tasks;

namespace EasyTicket.Services.Payment.Services
{
    public interface IExternalGatewayPaymentService
    {
        Task<bool> PerformPayment(PaymentInfo paymentInfo);
    }
}
