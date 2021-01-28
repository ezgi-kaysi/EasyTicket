using System;
using EasyTicket.Services.Discount.Entities;
using System.Threading.Tasks;

namespace EasyTicket.Services.Discount.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon> GetCouponByCode(string couponCode);
        Task UseCoupon(Guid couponId);
        Task<Coupon> GetCouponById(Guid couponId);
    }
}
