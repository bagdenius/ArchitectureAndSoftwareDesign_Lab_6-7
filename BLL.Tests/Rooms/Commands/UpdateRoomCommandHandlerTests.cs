using BLL.Tests.Common;
using CommandsAndQueries.Commands.RoomCommands.UpdateRoom;
using CommandsAndQueries.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Rooms.Commands
{
    public class UpdateRoomCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateRoomCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateRoomCommandHandler(unitOfWork);
            var updatednumber = "New number";
            var updatedFloor = 0;


            // Act
            await handler.Handle(new UpdateRoomCommand
            {
                Id = ContextFactory.RoomIdForUpdate,
                Number = updatednumber,
                Floor = updatedFloor
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Rooms.SingleOrDefaultAsync(room =>
            room.Id == ContextFactory.RoomIdForUpdate && room.Number == updatednumber &&
            room.Floor == updatedFloor));
        }

        [Fact]
        public async Task UpdateRoomCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateRoomCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateRoomCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}
