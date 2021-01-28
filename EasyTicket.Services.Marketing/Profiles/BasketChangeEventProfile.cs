using AutoMapper;

namespace EasyTicket.Services.Marketing.Profiles
{
    public class BasketChangeEventProfile : Profile
    {
        public BasketChangeEventProfile()
        {
            CreateMap<Models.BasketChangeEvent, Entities.BasketChangeEvent>();
        }
    }
}
