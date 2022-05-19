using MediatR;
using ViewModels;

namespace CommandsAndQueries.Queries.HotelQueries.GetHotel
{
    public class GetHotelQuery : IRequest<HotelVM>
    {
        public Guid Id { get; set; }
    }
}
