using MediatR;

namespace CommandsAndQueries.Commands.RoomCommands.RemoveRoom
{
    public class RemoveRoomCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
