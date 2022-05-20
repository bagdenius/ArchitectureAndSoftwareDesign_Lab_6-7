using AutoMapper;
using BLL.Tests.Common;
using CommandsAndQueries.Exceptions;
using CommandsAndQueries.Queries.HotelQueries.GetHotel;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWOrk.Abstract;
using ViewModels;
using Xunit;

namespace BLL.Tests.Hotels.Queries
{
    [Collection("QueryCollection")]
    public class GetHotelQueryHandlerTests
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetHotelQueryHandlerTests(QueryTestFixture fixture) =>
            (UnitOfWork, Mapper) = (fixture.unitOfWork, fixture.Mapper);

        [Fact]
        public async Task GetHotelQueryHandler_Success()
        {
            // Arrange
            var handler = new GetHotelQueryHandler(UnitOfWork, Mapper);

            // Act
            var result = await handler.Handle(new GetHotelQuery
            { Id = Guid.Parse("2B33CCB3-E65D-4B3C-9110-315F642E62FB") }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<HotelVM>();
            result.Name.ShouldBe("Name2");
            result.Stars.ShouldBe("Stars2");
            result.NumberOfFloors.ShouldBe(1);
            result.NumberOfRooms.ShouldBe(0);
            result.Address.ShouldBe("Address2");
            result.Phone.ShouldBe("Phone2");
        }

        [Fact]
        public async Task GetHotelQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetHotelQueryHandler(UnitOfWork, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetHotelQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
