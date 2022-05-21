using AutoMapper;
using BLL.Tests.Common;
using CommandsAndQueries.Exceptions;
using CommandsAndQueries.Queries.RoomQueries.GetRoomList;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWOrk.Abstract;
using ViewModels;
using Xunit;

namespace BLL.Tests.Rooms.Queries
{
    [Collection("QueryCollection")]
    public class GetRoomListQueryHandlerTests
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetRoomListQueryHandlerTests(QueryTestFixture fixture) =>
            (UnitOfWork, Mapper) = (fixture.unitOfWork, fixture.Mapper);

        [Fact]
        public async Task GetRoomListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetRoomListQueryHandler(UnitOfWork, Mapper);
            var hotelId = ContextFactory.HotelIdForUpdate;

            // Act
            var result = await handler.Handle(new GetRoomListQuery()
            { HotelId = hotelId }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<RoomVM>>();
            result.Count.ShouldBe(4);
        }

        [Fact]
        public async Task GetRoomListQueryHandler_FailedOnWrongHotelId()
        {
            // Arrange
            var handler = new GetRoomListQueryHandler(UnitOfWork, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetRoomListQuery
            { HotelId = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
