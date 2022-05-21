using AutoMapper;
using BLL.Tests.Common;
using CommandsAndQueries.Exceptions;
using CommandsAndQueries.Queries.RoomQueries.GetRoom;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWOrk.Abstract;
using ViewModels;
using Xunit;

namespace BLL.Tests.Rooms.Queries
{
    [Collection("QueryCollection")]
    public class GetRoomQueryHandlerTests
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetRoomQueryHandlerTests(QueryTestFixture fixture) =>
            (UnitOfWork, Mapper) = (fixture.unitOfWork, fixture.Mapper);

        [Fact]
        public async Task GetRoomQueryHandler_Success()
        {
            // Arrange
            var handler = new GetRoomQueryHandler(UnitOfWork, Mapper);

            // Act
            var result = await handler.Handle(new GetRoomQuery
            { Id = Guid.Parse("E5897075-AD06-4969-8B36-E791ED77C65A") }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<RoomVM>();
            result.Number.ShouldBe("2");
            result.Floor.ShouldBe(2);
            result.Cost.ShouldBe(2);
            result.Area.ShouldBe(2);
            result.RoomCategory.ShouldBe("Категорія2");
            result.ServicesAndAmenities.ShouldBe("Сервіси2");
            result.WindowsView.ShouldBe("Вид з вікна2");
            result.BookingState.ShouldBe("Вільний");
            result.BookingDates.ShouldBe(string.Empty);
        }

        [Fact]
        public async Task GetRoomQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetRoomQueryHandler(UnitOfWork, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetRoomQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
