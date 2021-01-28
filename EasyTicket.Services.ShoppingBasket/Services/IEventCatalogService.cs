using EasyTicket.Services.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace EasyTicket.Services.ShoppingBasket.Services
{
    public interface IEventCatalogService
    {
        Task<Event> GetEvent(Guid id);
    }
}