using BLL.Tests.Common;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandsAndQueries.Commands.HotelCommands.UpdateHotel;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using CommandsAndQueries.Exceptions;

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
