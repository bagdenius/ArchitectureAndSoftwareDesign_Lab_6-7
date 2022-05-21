using BLL.Tests.Common;
using CommandsAndQueries.Exceptions;
using CommandsAndQueries.ResumeCommands.CreateResume;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Customers.Commands
{
    public class AddCustomerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddCustomerCommandHandler_Success()
        {
            // Arrange
            var handler = new AddCustomerCommandHandler(unitOfWork);
            var RoomId = ContextFactory.RoomIdForUpdate;
            var Name = "Name";
            var Surname = "Surname";
            var Patronymic = "Patronymic";
            var Gender = "Gender";
            var Passport = "Passport";
            var BirthDate = DateTime.Today;
            var Phone = "Phone";
            var Email = "Email";
            var BookingStartDate = DateTime.Today;
            var BookingEndDate = DateTime.Today;

            // Act
            var customerId = await handler.Handle(
                new AddCustomerCommand
                {
                    RoomId = RoomId,
                    Name = Name,
                    Surname = Surname,
                    Patronymic = Patronymic,
                    Gender = Gender,
                    Passport = Passport,
                    BirthDate = BirthDate,
                    Phone = Phone,
                    Email = Email,
                    BookingStartDate = BookingStartDate,
                    BookingEndDate = BookingEndDate
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Customers.SingleOrDefaultAsync(customer =>
                customer.Id == customerId && customer.RoomId == RoomId &&
                customer.Name == Name && customer.Surname == Surname &&
                customer.Patronymic == Patronymic && customer.Gender == Gender &&
                customer.Passport == Passport && customer.BirthDate == BirthDate &&
                customer.Phone == Phone && customer.Email == Email));
        }

        [Fact]
        public async Task AddCustomerCommandHandler_FailedOnRoomId()
        {
            // Arrange
            var handler = new AddCustomerCommandHandler(unitOfWork);
            var RoomId = Guid.NewGuid();

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new AddCustomerCommand
            { RoomId = RoomId }, CancellationToken.None));
        }
    }
}
