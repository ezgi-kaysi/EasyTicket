using EasyTicket.Services.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace EasyTicket.Services.ShoppingBasket.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(Event theEvent);
        Task<bool> EventExists(Guid eventId);
        Task<bool> SaveChanges();
    }
}