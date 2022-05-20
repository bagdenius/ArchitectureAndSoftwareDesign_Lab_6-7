using AutoMapper;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels;

namespace CommandsAndQueries.Queries.HotelQueries.GetHotelList
{
    public class GetHotelListQueryHandler : IRequestHandler<GetHotelListQuery, List<HotelVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetHotelListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<List<HotelVM>> Handle(GetHotelListQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _unitOfWork.Hotels.GetAllAsync(cancellationToken);
            return _mapper.Map<List<HotelVM>>(hotels);
        }
    }
}
