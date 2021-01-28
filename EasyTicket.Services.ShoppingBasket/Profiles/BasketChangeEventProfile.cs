using AutoMapper;
using EasyTicket.Services.ShoppingBasket.Entities;
using EasyTicket.Services.ShoppingBasket.Models;

namespace EasyTicket.Services.ShoppingBasket.Profiles
{
    public class BasketChangeEventProfile: Profile
    {
        public BasketChangeEventProfile()
        {
            CreateMap<BasketChangeEvent, BasketChangeEventForPublication>().ReverseMap();
        }
    }
}
