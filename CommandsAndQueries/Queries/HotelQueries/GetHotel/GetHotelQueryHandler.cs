using AutoMapper;
using CommandsAndQueries.Exceptions;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.Queries.HotelQueries.GetHotel
{
    public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, HotelVM>
    {
        private readonly IService<Hotel> _service;
        private readonly IMapper _mapper;
        public GetHotelQueryHandler(IService<Hotel> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<HotelVM> Handle(GetHotelQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _service.GetAsync(request.Id, cancellationToken);
            if (hotel == null || hotel.Id != request.Id)
                throw new NotFoundException(nameof(Hotel), request.Id);
            return _mapper.Map<HotelVM>(hotel);
        }
    }
}
