using AutoMapper;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.ResumeCommands.CreateResume
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
    {
        private readonly IService<Customer> _service;
        private readonly IMapper _mapper;
        public AddCustomerCommandHandler(IService<Customer> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
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
