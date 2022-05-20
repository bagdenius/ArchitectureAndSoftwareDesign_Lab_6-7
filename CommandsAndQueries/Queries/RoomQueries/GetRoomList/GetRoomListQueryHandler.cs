using AutoMapper;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels;

namespace CommandsAndQueries.Queries.RoomQueries.GetRoomList
{
    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, List<RoomVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetRoomListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<List<RoomVM>> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _unitOfWork.Rooms.GetRoomsAsync(request.HotelId, cancellationToken);
            return _mapper.Map<List<RoomVM>>(rooms);
        }
    }
}
