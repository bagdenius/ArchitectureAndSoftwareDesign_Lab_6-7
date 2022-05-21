using MediatR;
using ViewModels;

namespace CommandsAndQueries.ResumeQueries.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<List<CustomerVM>>
    {

    }
}
