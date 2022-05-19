using AutoMapper;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace Queries.ResumeCommands.CreateResume
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IService<Customer> _service;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(IService<Customer> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerVM
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Gender = request.Gender,
                Passport = request.Passport,
                BirthDate = request.BirthDate,
                Phone = request.Phone,
                Email = request.Email
            };
            await _service.AddAsync(_mapper.Map<Customer>(customer), cancellationToken);
            await _service.SaveAsync(cancellationToken);
            return customer.Id;
        }
    }
}
