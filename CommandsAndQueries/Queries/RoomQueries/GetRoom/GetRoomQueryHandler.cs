using AutoMapper;
using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels;

namespace CommandsAndQueries.Queries.RoomQueries.GetRoom
{
    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, RoomVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetRoomQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<RoomVM> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.Rooms.GetAsync(request.Id, cancellationToken);
            if (room == null || room.Id != request.Id)
                throw new NotFoundException(nameof(Room), request.Id);
            return _mapper.Map<RoomVM>(room);
        }
    }
}
