using AutoMapper;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.Queries.HotelQueries.GetHotelList
{
    public class GetHotelListQueryHandler : IRequestHandler<GetHotelListQuery, List<HotelVM>>
    {
        private readonly IService<Hotel> _service;
        private readonly IMapper _mapper;
        public GetHotelListQueryHandler(IService<Hotel> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<List<HotelVM>> Handle(GetHotelListQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _service.GetAllAsync(cancellationToken);
            return _mapper.Map<List<HotelVM>>(hotels);
        }
    }
}
