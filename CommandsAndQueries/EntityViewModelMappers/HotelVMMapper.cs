using AutoMapper;
using Entities;
using ViewModels;

namespace EntityViewModelMappers
{
    public class HotelVMMapper : Profile
    {
        public HotelVMMapper()
        {
            CreateMap<Hotel, HotelVM>().ReverseMap();
        }
    }
}
