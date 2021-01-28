using EasyTicket.Services.ShoppingBasket.DbContexts;
using EasyTicket.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyTicket.Services.ShoppingBasket.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ShoppingBasketContext ShoppingBasketContext;

        public EventRepository(ShoppingBasketContext ShoppingBasketContext)
        {
            this.ShoppingBasketContext = ShoppingBasketContext;
        }

        public async Task<bool> EventExists(Guid eventId)
        {
            return await ShoppingBasketContext.Events.AnyAsync(e => e.EventId == eventId);
        }

        public void AddEvent(Event theEvent)
        {
            ShoppingBasketContext.Events.Add(theEvent);

        }

        public async Task<bool> SaveChanges()
        {
            return (await ShoppingBasketContext.SaveChangesAsync() > 0);
        }
    }
}
