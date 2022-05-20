using MediatR;
using ViewModels;

namespace CommandsAndQueries.Queries.RoomQueries.GetRoomList
{
    public class GetRoomListQuery : IRequest<List<RoomVM>>
    {
        public Guid HotelId { get; set; }
    }
}
