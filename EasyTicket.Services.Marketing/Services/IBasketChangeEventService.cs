using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTicket.Services.Marketing.Models;

namespace EasyTicket.Services.Marketing.Services
{
    public interface IBasketChangeEventService
    {
        Task<List<BasketChangeEvent>> GetBasketChangeEvents(DateTime startDate, int max);
    }
}