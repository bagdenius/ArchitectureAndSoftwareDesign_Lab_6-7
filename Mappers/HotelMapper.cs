using AutoMapper;
using Domain;
using Entities;
using ViewModels;

namespace Mappers
{
    public class HotelMapper : Profile
    {
        public HotelMapper()
        {
            CreateMap<Hotel, HotelEntity>().ReverseMap();
            CreateMap<Hotel, HotelVM>().ReverseMap();
        }
    }
}
