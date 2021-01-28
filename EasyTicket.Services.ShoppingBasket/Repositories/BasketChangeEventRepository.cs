using System;
using System.Collections.Generic;
using System.Linq;
using EasyTicket.Services.ShoppingBasket.DbContexts;
using EasyTicket.Services.ShoppingBasket.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTicket.Services.ShoppingBasket.Repositories
{
    public class BasketChangeEventRepository: IBasketChangeEventRepository
    {
        private readonly ShoppingBasketContext shoppingBasketContext;

        public BasketChangeEventRepository(ShoppingBasketContext ShoppingBasketContext)
        {
            this.shoppingBasketContext = ShoppingBasketContext;
        }

        public async Task AddBasketEvent(BasketChangeEvent basketChangeEvent)
        {
            await shoppingBasketContext.BasketChangeEvents.AddAsync(basketChangeEvent);
            await shoppingBasketContext.SaveChangesAsync();
        }

        public async Task<List<BasketChangeEvent>> GetBasketChangeEvents(DateTime startDate, int max)
        {
            return await shoppingBasketContext.BasketChangeEvents.Where(b => b.InsertedAt > startDate)
                .OrderBy(b => b.InsertedAt).Take(max).ToListAsync();
        }
    }
}
