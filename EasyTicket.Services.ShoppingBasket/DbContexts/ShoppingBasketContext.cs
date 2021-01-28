using EasyTicket.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyTicket.Services.ShoppingBasket.DbContexts
{
    public class ShoppingBasketContext : DbContext
    {
        public ShoppingBasketContext(DbContextOptions<ShoppingBasketContext> options)
        : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<BasketChangeEvent> BasketChangeEvents { get; set; }
    }
}
