using BLL.Tests.Common;
using CommandsAndQueries.Commands.HotelCommands.UpdateHotel;
using CommandsAndQueries.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Hotels.Commands
{
    public class UpdateHotelCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateHotelCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateHotelCommandHandler(unitOfWork);
            var updatedName = "New Name";

            // Act
            await handler.Handle(new UpdateHotelCommand
            {
                Id = ContextFactory.HotelIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Hotels.SingleOrDefaultAsync(hotel =>
            hotel.Id == ContextFactory.HotelIdForUpdate && hotel.Name == updatedName));
        }

        [Fact]
        public async Task UpdateHotelCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateHotelCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateHotelCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}
