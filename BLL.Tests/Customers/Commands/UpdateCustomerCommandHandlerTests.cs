using BLL.Tests.Common;
using CommandsAndQueries.Exceptions;
using CommandsAndQueries.ResumeCommands.UpdateResume;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Customers.Commands
{
    public class UpdateCustomerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateCustomerCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateCustomerCommandHandler(unitOfWork);
            var updatedName = "New name";


            // Act
            await handler.Handle(new UpdateCustomerCommand
            {
                Id = ContextFactory.CustomerIdForUpdate,
                RoomId = ContextFactory.RoomIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Customers.SingleOrDefaultAsync(customer =>
            customer.Id == ContextFactory.CustomerIdForUpdate && customer.Name == updatedName &&
            customer.RoomId == ContextFactory.RoomIdForUpdate));
        }

        [Fact]
        public async Task UpdateCustomerCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateCustomerCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateCustomerCommand
            {
                Id = Guid.NewGuid(),
                RoomId = ContextFactory.RoomIdForUpdate
            }, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateCustomerCommandHandler_FailOnWrongRoomId()
        {
            // Arrange
            var handler = new UpdateCustomerCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateCustomerCommand
            {
                Id = ContextFactory.CustomerIdForUpdate,
                RoomId = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}
