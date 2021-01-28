using System.Threading.Tasks;
using EasyTicket.Services.Marketing.Entities;

namespace EasyTicket.Services.Marketing.Repositories
{
    public interface IBasketChangeEventRepository
    {
        Task AddBasketChangeEvent(BasketChangeEvent basketChangeEvent);
    }
}