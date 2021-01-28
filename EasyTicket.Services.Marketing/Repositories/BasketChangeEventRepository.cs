using EasyTicket.Services.Marketing.DbContexts;
using EasyTicket.Services.Marketing.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EasyTicket.Services.Marketing.Repositories
{
    public class BasketChangeEventRepository : IBasketChangeEventRepository
    {
        private readonly DbContextOptions<MarketingDbContext> dbContextOptions;

        public BasketChangeEventRepository(DbContextOptions<MarketingDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task AddBasketChangeEvent(BasketChangeEvent basketChangeEvent)
        {
            await using (var marketingDbContext = new MarketingDbContext(dbContextOptions))
            {
                await marketingDbContext.BasketChangeEvents.AddAsync(basketChangeEvent);
                await marketingDbContext.SaveChangesAsync();
            }
        }
    }
}
