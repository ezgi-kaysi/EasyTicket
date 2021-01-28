using AutoMapper;
using EasyTicket.Services.Discount.Entities;
using EasyTicket.Services.Discount.Models;

namespace EasyTicket.Services.Discount.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
