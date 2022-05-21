using CommandsAndQueries.Exceptions;
using Entities;
using MediatR;
using UnitOfWOrk.Abstract;
using ViewModels.enums;

namespace CommandsAndQueries.ResumeCommands.CreateResume
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddCustomerCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var room = _unitOfWork.Rooms.Get(request.RoomId);
            if (room == null)
                throw new NotFoundException(nameof(Room), request.RoomId);
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
            room.BookingState = BookingState.Заброньований.ToString();
            room.BookingDates = $"{request.BookingStartDate.ToShortDateString()} - " +
                $"{request.BookingEndDate.ToShortDateString()}";
            var hotel = _unitOfWork.Hotels.Get(room.HotelId);
            hotel.NumberOfRooms++;
            await _unitOfWork.Customers.AddAsync(customer, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return customer.Id;
        }
    }
}
