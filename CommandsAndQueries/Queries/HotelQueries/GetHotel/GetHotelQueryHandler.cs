using AutoMapper;
using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels;

namespace CommandsAndQueries.Queries.HotelQueries.GetHotel
{
    public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, HotelVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetHotelQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<HotelVM> Handle(GetHotelQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _unitOfWork.Hotels.GetAsync(request.Id, cancellationToken);
            if (hotel == null || hotel.Id != request.Id)
                throw new NotFoundException(nameof(Hotel), request.Id);
            return _mapper.Map<HotelVM>(hotel);
        }
    }
}
