using MediatR;
using ViewModels;

namespace CommandsAndQueries.Queries.HotelQueries.GetHotelList
{
    public class GetHotelListQuery : IRequest<List<HotelVM>>
    {

    }
}
