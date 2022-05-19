using AutoMapper;
using Queries.Exceptions;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace Queries.ResumeCommands.UpdateResume
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IService<Resume> _service;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(IService<Resume> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var resume = _mapper.Map<ResumeVM>(await _service.GetAsync(request.Id, cancellationToken));
            if (resume == null || resume.Id != request.Id)
                throw new NotFoundException(nameof(Resume), request.Id);
            resume.Id = request.Id;
            resume.UserId = request.UserId;
            resume.Title = request.Title;
            resume.City = request.City;
            resume.Position = request.Position;
            resume.Salary = request.Salary;
            resume.Employement = request.Employement;
            resume.Experience = request.Experience;
            resume.Content = request.Content;
            resume.EditDate = DateTime.Now;
            await _service.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
