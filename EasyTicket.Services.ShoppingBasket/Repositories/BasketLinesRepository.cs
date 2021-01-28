using EasyTicket.Services.ShoppingBasket.DbContexts;
using EasyTicket.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTicket.Services.ShoppingBasket.Repositories
{
    public class BasketLinesRepository : IBasketLinesRepository
    {
        private readonly ShoppingBasketContext ShoppingBasketContext;

        public BasketLinesRepository(ShoppingBasketContext ShoppingBasketContext)
        {
            this.ShoppingBasketContext = ShoppingBasketContext;
        }

        public async Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId)
        {
            return await ShoppingBasketContext.BasketLines.Include(bl => bl.Event)
                .Where(b => b.BasketId == basketId).ToListAsync();
        }

        public async Task<BasketLine> GetBasketLineById(Guid basketLineId)
        {
            return await ShoppingBasketContext.BasketLines.Include(bl => bl.Event)
                .Where(b => b.BasketLineId == basketLineId).FirstOrDefaultAsync();
        }

        public async Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine)
        {
            var existingLine = await ShoppingBasketContext.BasketLines.Include(bl => bl.Event)
                .Where(b => b.BasketId == basketId && b.EventId == basketLine.EventId).FirstOrDefaultAsync();
            if (existingLine == null)
            {
                basketLine.BasketId = basketId;
                ShoppingBasketContext.BasketLines.Add(basketLine);
                return basketLine;
            }
            existingLine.TicketAmount += basketLine.TicketAmount;
            return existingLine;
        }

        public void UpdateBasketLine(BasketLine basketLine)
        {
            // empty on purpose
        }
        
        public void RemoveBasketLine(BasketLine basketLine)
        {
            ShoppingBasketContext.BasketLines.Remove(basketLine);
        }

        public async Task<bool> SaveChanges()
        {
            return (await ShoppingBasketContext.SaveChangesAsync() > 0);
        }
    }
}
