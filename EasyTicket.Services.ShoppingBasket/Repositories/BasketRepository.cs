using EasyTicket.Services.ShoppingBasket.DbContexts;
using EasyTicket.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTicket.Services.ShoppingBasket.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ShoppingBasketContext ShoppingBasketContext;

        public BasketRepository(ShoppingBasketContext ShoppingBasketContext)
        {
            this.ShoppingBasketContext = ShoppingBasketContext;
        }

        public async Task<Basket> GetBasketById(Guid basketId)
        {
            return await ShoppingBasketContext.Baskets.Include(sb => sb.BasketLines)
                .Where(b => b.BasketId == basketId).FirstOrDefaultAsync();
        }

        public async Task<bool> BasketExists(Guid basketId)
        {
            return await ShoppingBasketContext.Baskets
                .AnyAsync(b => b.BasketId == basketId);
        }

        public async Task ClearBasket(Guid basketId)
        {
            var basketLinesToClear = ShoppingBasketContext.BasketLines.Where(b => b.BasketId == basketId);
            ShoppingBasketContext.BasketLines.RemoveRange(basketLinesToClear);

            var basket = ShoppingBasketContext.Baskets.FirstOrDefault(b => b.BasketId == basketId);
            if (basket != null) basket.CouponId = null;

            await SaveChanges();
        }

        public void AddBasket(Basket basket)
        {
            ShoppingBasketContext.Baskets.Add(basket);
        }

        public async Task<bool> SaveChanges()
        {
            return (await ShoppingBasketContext.SaveChangesAsync() > 0);
        }
    }
}
