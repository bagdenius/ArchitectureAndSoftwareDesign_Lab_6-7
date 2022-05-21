using AutoMapper;
using BLL.Tests.Common;
using CommandsAndQueries.Exceptions;
using CommandsAndQueries.ResumeQueries.GetCustomer;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWOrk.Abstract;
using ViewModels;
using Xunit;

namespace BLL.Tests.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerQueryHandlerTests
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetCustomerQueryHandlerTests(QueryTestFixture fixture) =>
            (UnitOfWork, Mapper) = (fixture.unitOfWork, fixture.Mapper);

        [Fact]
        public async Task GetCustomerQueryHandler_Success()
        {
            // Arrange
            var handler = new GetCustomerQueryHandler(UnitOfWork, Mapper);

            // Act
            var result = await handler.Handle(new GetCustomerQuery
            { Id = Guid.Parse("5C8AFB2C-BA2A-419D-930E-0AD0207DC187") }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CustomerVM>();
            result.RoomId.ShouldBe(ContextFactory.RoomIdForUpdate);
            result.Name.ShouldBe("Name2");
            result.Surname.ShouldBe("Surname2");
            result.Patronymic.ShouldBe("Patronymic2");
            result.Passport.ShouldBe("Passport2");
            result.Gender.ShouldBe("Gender2");
            result.BirthDate.ShouldBe(DateTime.Today);
            result.Phone.ShouldBe("Phone2");
            result.Email.ShouldBe("Email2");
        }

        [Fact]
        public async Task GetCustomerQueryHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new GetCustomerQueryHandler(UnitOfWork, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetCustomerQuery
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
