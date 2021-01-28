using System;
using EasyTicket.Web.Models;
using Microsoft.AspNetCore.Http;

namespace EasyTicket.Web.Extensions
{
    public static  class RequestCookieCollection
    {
        public static Guid GetCurrentBasketId(this IRequestCookieCollection cookies, Settings settings)
        {
            Guid.TryParse(cookies[settings.BasketIdCookieName], out Guid basketId);
            return basketId;
        }
    }
}
