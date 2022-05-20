using AutoMapper;
using Entities;
using ViewModels;

namespace EntityViewModelMappers
{
    public class HotelMapper : Profile
    {
        public HotelMapper()
        {
            CreateMap<Hotel, HotelVM>().ReverseMap();
        }
    }
}
