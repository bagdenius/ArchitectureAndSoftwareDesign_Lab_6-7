using AutoMapper;
using Domain;
using Entities;
using ViewModels;

namespace Mappers
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<Room, RoomEntity>().ReverseMap();
            CreateMap<RoomVM, Room>().ReverseMap();
        }
    }
}
