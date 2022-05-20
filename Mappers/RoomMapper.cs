using AutoMapper;
using Entities;
using ViewModels;

namespace EntityViewModelMappers
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<RoomVM, Room>().ReverseMap();
        }
    }
}
