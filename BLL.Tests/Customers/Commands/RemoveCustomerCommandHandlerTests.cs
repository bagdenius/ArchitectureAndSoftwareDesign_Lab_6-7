using BLL.Tests.Common;
using CommandsAndQueries.Exceptions;
using CommandsAndQueries.ResumeCommands.RemoveResume;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Customers.Commands
{
    public class RemoveCustomerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task RemoveCustomerCommandHandler_Success()
        {
            // Arrange 
            var handler = new RemoveCustomerCommandHandler(unitOfWork);

            // Act
            await handler.Handle(new RemoveCustomerCommand
            {
                Id = ContextFactory.CustomerIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Customers.SingleOrDefaultAsync(customer =>
            customer.Id == ContextFactory.CustomerIdForDelete));
        }

        [Fact]
        public async Task RemoveCustomerCommandHandler_FailedOnWrongId()
        {
            // Arrange
            var handler = new RemoveCustomerCommandHandler(unitOfWork);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new RemoveCustomerCommand
            { Id = Guid.NewGuid() }, CancellationToken.None));
        }
    }
}
