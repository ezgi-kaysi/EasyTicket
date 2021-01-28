using AutoMapper;
using EasyTicket.Services.ShoppingBasket.Messages;
using EasyTicket.Services.ShoppingBasket.Models;

namespace EasyTicket.Services.ShoppingBasket.Profiles
{
    public class BasketCheckoutProfile: Profile
    {
        public BasketCheckoutProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutMessage>().ReverseMap();
        }
    }
}
