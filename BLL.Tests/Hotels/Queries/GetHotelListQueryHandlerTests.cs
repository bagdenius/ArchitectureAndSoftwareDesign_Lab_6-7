using AutoMapper;
using BLL.Tests.Common;
using CommandsAndQueries.Queries.HotelQueries.GetHotelList;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWOrk.Abstract;
using ViewModels;
using Xunit;

namespace BLL.Tests.Hotels.Queries
{
    [Collection("QueryCollection")]
    public class GetHotelListQueryHandlerTests
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetHotelListQueryHandlerTests(QueryTestFixture fixture) =>
            (UnitOfWork, Mapper) = (fixture.unitOfWork, fixture.Mapper);

        [Fact]
        public async Task GetHotelListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetHotelListQueryHandler(UnitOfWork, Mapper);

            // Act
            var result = await handler.Handle(new GetHotelListQuery() { }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<HotelVM>>();
            result.Count.ShouldBe(4);
        }
    }
}
