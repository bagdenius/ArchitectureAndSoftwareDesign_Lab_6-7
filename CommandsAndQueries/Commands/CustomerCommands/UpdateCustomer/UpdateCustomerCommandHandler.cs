using AutoMapper;
using CommandsAndQueries.Exceptions;
using Domain;
using MediatR;
using Services.Abstract;
using ViewModels;

namespace CommandsAndQueries.ResumeCommands.UpdateResume
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IService<Customer> _service;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(IService<Customer> service, IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<CustomerVM>(await _service.GetAsync(request.Id, cancellationToken));
            if (customer == null || customer.Id != request.Id)
                throw new NotFoundException(nameof(Customer), request.Id);
            customer.Id = request.Id;
            customer.RoomId = request.RoomId;
            customer.Name = request.Name;
            customer.Surname = request.Surname;
            customer.Patronymic = request.Patronymic;
            customer.Gender = request.Gender;
            customer.Passport = request.Passport;
            customer.BirthDate = request.BirthDate;
            customer.Phone = request.Phone;
            customer.Email = request.Email;
            await _service.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
