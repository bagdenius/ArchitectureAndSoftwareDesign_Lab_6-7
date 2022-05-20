﻿using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;

namespace CommandsAndQueries.ResumeCommands.UpdateResume
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetAsync(request.Id, cancellationToken);
            if (customer == null)
                throw new NotFoundException(nameof(Customer), request.Id);
            customer.Id = request.Id;
            customer.RoomId = request.RoomId;
            customer.Name = request.Name;
            customer.Surname = request.Surname;
            customer.Patronymic = request.Patronymic;
            customer.Gender = request.Gender;
            customer.Passport = request.Passport;
            customer.BirthDate = (DateTime)request.BirthDate;
            customer.Phone = request.Phone;
            customer.Email = request.Email;
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
