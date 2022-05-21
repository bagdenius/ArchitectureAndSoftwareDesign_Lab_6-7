using BLL.Tests.Common;
using CommandsAndQueries.Commands.RoomCommands.RemoveRoom;
using CommandsAndQueries.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Rooms.Commands
{
    public class RemoveRoomCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveRoomCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveRoomCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveRoomCommand
            {
                Id = ContextFactory.RoomIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Rooms.SingleOrDefaultAsync(room =>
            room.Id == ContextFactory.RoomIdForDelete));
        }

        [Fact]
        public async Task RemoveRoomCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveRoomCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveRoomCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
