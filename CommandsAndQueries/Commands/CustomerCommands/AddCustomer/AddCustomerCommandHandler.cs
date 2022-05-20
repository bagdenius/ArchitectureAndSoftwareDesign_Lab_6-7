using Entities;
using MediatR;
using UnitOfWOrk.Abstract;

namespace CommandsAndQueries.ResumeCommands.CreateResume
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddCustomerCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                RoomId = request.RoomId,
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Gender = request.Gender,
                Passport = request.Passport,
                BirthDate = (DateTime)request.BirthDate,
                Phone = request.Phone,
                Email = request.Email
            };
            await _unitOfWork.Customers.AddAsync(customer, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return customer.Id;
        }
    }
}
