using AutoMapper;
using Entities;
using ViewModels;

namespace EntityViewModelMappers
{
    public class RoomVMMapper : Profile
    {
        public RoomVMMapper()
        {
            CreateMap<Room, RoomVM>().ReverseMap();
        }
    }
}
