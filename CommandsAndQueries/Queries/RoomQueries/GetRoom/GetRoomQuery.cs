using MediatR;
using ViewModels;

namespace CommandsAndQueries.Queries.RoomQueries.GetRoom
{
    public class GetRoomQuery : IRequest<RoomVM>
    {
        public Guid Id { get; set; }
    }
}
