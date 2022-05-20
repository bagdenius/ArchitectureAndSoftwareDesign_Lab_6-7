using AutoMapper;
using CommandsAndQueries.Commands.RoomCommands.AddRoom;
using CommandsAndQueries.Commands.RoomCommands.UpdateRoom;
using UI.WebAPI.Models.Room;

namespace UI.WebAPI.ModelCommandMappers
{
    public class RoomModelMapper : Profile
    {
        public RoomModelMapper()
        {
            CreateMap<AddRoomModel, AddRoomCommand>();
            CreateMap<UpdateRoomModel, UpdateRoomCommand>();
        }
    }
}
