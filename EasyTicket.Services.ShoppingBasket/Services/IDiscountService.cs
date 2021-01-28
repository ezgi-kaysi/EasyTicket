using EasyTicket.Services.ShoppingBasket.Models;
using System;
using System.Threading.Tasks;

namespace EasyTicket.Services.ShoppingBasket.Services
{
    public interface IDiscountService
    {
        Task<Coupon> GetCoupon(Guid couponId);
        Task<Coupon> GetCouponWithError(Guid couponId);
    }
}
