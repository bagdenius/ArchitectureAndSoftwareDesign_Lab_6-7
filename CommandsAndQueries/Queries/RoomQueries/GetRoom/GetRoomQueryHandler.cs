using AutoMapper;
using CommandsAndQueries.Exceptions;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.Queries.RoomQueries.GetRoom
{
    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, RoomVM>
    {
        private readonly IService<Room> _service;
        private readonly IMapper _mapper;
        public GetRoomQueryHandler(IService<Room> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<RoomVM> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var room = await _service.GetAsync(request.Id, cancellationToken);
            if (room == null || room.Id != request.Id)
                throw new NotFoundException(nameof(Room), request.Id);
            return _mapper.Map<RoomVM>(room);
        }
    }
}
