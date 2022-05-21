using AutoMapper;
using BLL.Tests.Common;
using CommandsAndQueries.ResumeQueries.GetCustomerList;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWOrk.Abstract;
using ViewModels;
using Xunit;

namespace BLL.Tests.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerListQueryHandlerTests
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetCustomerListQueryHandlerTests(QueryTestFixture fixture) =>
            (UnitOfWork, Mapper) = (fixture.unitOfWork, fixture.Mapper);

        [Fact]
        public async Task GetCustomerListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetCustomerListQueryHandler(UnitOfWork, Mapper);

            // Act
            var result = await handler.Handle(new GetCustomerListQuery() { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<CustomerVM>>();
            result.Count.ShouldBe(4);
        }
    }
}
