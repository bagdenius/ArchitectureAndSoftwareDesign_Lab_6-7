using AutoMapper;
using CommandsAndQueries.Exceptions;
using Entities;
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
            var hotel = await _unitOfWork.Hotels.GetAsync(request.HotelId, cancellationToken);
            if (hotel == null)
                throw new NotFoundException(nameof(Hotel), request.HotelId);
            var rooms = await _unitOfWork.Rooms.GetRoomsAsync(request.HotelId, cancellationToken);
            return _mapper.Map<List<RoomVM>>(rooms);
        }
    }
}
