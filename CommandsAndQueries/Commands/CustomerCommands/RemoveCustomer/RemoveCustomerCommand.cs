using MediatR;

namespace Queries.ResumeCommands.RemoveResume
{
    public class RemoveCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
