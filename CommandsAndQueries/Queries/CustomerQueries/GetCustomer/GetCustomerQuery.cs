using MediatR;
using ViewModels;

namespace CommandsAndQueries.ResumeQueries.GetResume
{
    public class GetCustomerQuery : IRequest<CustomerVM>
    {
        public Guid Id { get; set; }
    }
}
