using BLL.Tests.Common;
using CommandsAndQueries.Commands.HotelCommands.AddHotel;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests.Hotels.Commands
{
    public class AddHotelCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddHotelCommandHandler_Success()
        {
            // Arrange 
            var handler = new AddHotelCommandHandler(unitOfWork);
            var Name = "Hotel name";
            var Stars = "Hotel stars";
            var NumberOfFloors = 1;
            var Address = "Hotel address";
            var Phone = "Hotel phone";

            // Act
            var hotelId = await handler.Handle(
                new AddHotelCommand
                {
                    Name = Name,
                    Stars = Stars,
                    NumberOfFloors = NumberOfFloors,
                    Address = Address,
                    Phone = Phone
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Hotels.SingleOrDefaultAsync(hotel =>
                hotel.Id == hotelId && hotel.Name == Name &&
                hotel.Stars == Stars && hotel.NumberOfFloors == NumberOfFloors &&
                hotel.Address == Address && hotel.Phone == Phone));
        }
    }
}
