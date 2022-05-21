using BLL.Tests.Common;
using CommandsAndQueries.Commands.HotelCommands.RemoveHotel;
using CommandsAndQueries.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Hotels.Commands
{
    public class RemoveHotelCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveHotelCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveHotelCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveHotelCommand
            {
                Id = ContextFactory.HotelIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Hotels.SingleOrDefaultAsync(hotel =>
            hotel.Id == ContextFactory.HotelIdForDelete));
        }

        [Fact]
        public async Task RemoveHotelCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveHotelCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveHotelCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
