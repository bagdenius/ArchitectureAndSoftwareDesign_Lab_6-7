using AutoMapper;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.Queries.RoomQueries.GetRoomList
{
    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, List<RoomVM>>
    {
        private readonly IService<Room> _service;
        private readonly IMapper _mapper;
        public GetRoomListQueryHandler(IService<Room> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<List<RoomVM>> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _service.GetAllAsync(cancellationToken);
            return _mapper.Map<List<RoomVM>>(rooms);
        }
    }
}
