using MediatR;

namespace CommandsAndQueries.Commands.HotelCommands.RemoveHotel
{
    public class RemoveHotelCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
