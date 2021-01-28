using AutoMapper;
using EasyTicket.Grpc;

namespace EasyTicket.Services.EventCatalog.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDto>().ReverseMap();
            CreateMap<Entities.Category, Category>().ReverseMap();
        }
    }
}
