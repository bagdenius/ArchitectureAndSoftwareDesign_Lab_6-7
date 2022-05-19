using MediatR;
using ViewModels;

namespace CommandsAndQueries.ResumeQueries.GetResumeList
{
    public class GetCustomerListQuery : IRequest<List<CustomerVM>>
    {

    }
}
