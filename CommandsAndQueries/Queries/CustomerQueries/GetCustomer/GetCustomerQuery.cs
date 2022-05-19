using MediatR;
using ViewModels;

namespace Queries.ResumeQueries.GetResume
{
    public class GetCustomerQuery : IRequest<ResumeVM>
    {
        public Guid Id { get; set; }
    }
}
