using MediatR;
using ViewModels;

namespace CommandsAndQueries.ResumeQueries.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerVM>
    {
        public Guid Id { get; set; }
    }
}
