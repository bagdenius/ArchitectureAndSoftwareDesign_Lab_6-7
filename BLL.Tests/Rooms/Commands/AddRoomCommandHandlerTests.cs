using BLL.Tests.Common;
using CommandsAndQueries.Commands.RoomCommands.AddRoom;
using CommandsAndQueries.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Rooms.Commands
{
    public class AddRoomCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddRoomCommandHandler_Success()
        {
            // Arrange
            var handler = new AddRoomCommandHandler(unitOfWork);
            var HotelId = ContextFactory.HotelIdForUpdate;
            var Number = "Room number";
            var Floor = 1;
            double Cost = 1;
            double Area = 1;
            var RoomCategory = "Room category";
            var ServicesAndAmenities = "Room services and amenities";
            var WindowView = "Room window view";

            // Act
            var roomId = await handler.Handle(
                new AddRoomCommand
                {
                    HotelId = HotelId,
                    Number = Number,
                    Floor = Floor,
                    Cost = Cost,
                    Area = Area,
                    RoomCategory = RoomCategory,
                    ServicesAndAmenities = ServicesAndAmenities,
                    WindowsView = WindowView
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Rooms.SingleOrDefaultAsync(room =>
                room.Id == roomId && room.Number == Number &&
                room.Floor == Floor && room.Cost == Cost &&
                room.Area == Area && room.RoomCategory == RoomCategory &&
                room.ServicesAndAmenities == ServicesAndAmenities &&
                room.WindowsView == WindowView && room.HotelId == HotelId));
        }

        [Fact]
        public async Task AddRoomCommandHandler_FailedOnWrongHotelId()
        {
            // Arrange
            var handler = new AddRoomCommandHandler(unitOfWork);
            var HotelId = Guid.NewGuid();

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new AddRoomCommand
            { HotelId = HotelId }, CancellationToken.None));
        }
    }
}
