using MediatR;

namespace CommandsAndQueries.ResumeCommands.RemoveResume
{
    public class RemoveCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
