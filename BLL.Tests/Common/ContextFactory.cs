using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BLL.Tests.Common
{
    public static class ContextFactory
    {
        public static Guid HotelIdForUpdate = Guid.NewGuid();
        public static Guid HotelIdForDelete = Guid.NewGuid();

        public static Guid RoomIdForUpdate = Guid.NewGuid();
        public static Guid RoomIdForDelete = Guid.NewGuid();

        public static Guid CustomerIdForUpdate = Guid.NewGuid();
        public static Guid CustomerIdForDelete = Guid.NewGuid();

        public static DatabaseContext Create()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DatabaseContext(options);
            context.Database.EnsureCreated();
            context.Hotels.AddRange(
                new Hotel
                {
                    Id = Guid.Parse("2630C939-A77F-4D7B-841B-02B50AFA8BE1"),
                    Name = "Name1",
                    Stars = "Stars1",
                    NumberOfRooms = 0,
                    NumberOfFloors = 1,
                    Address = "Address1",
                    Phone = "Phone1"
                },
                new Hotel
                {
                    Id = Guid.Parse("2B33CCB3-E65D-4B3C-9110-315F642E62FB"),
                    Name = "Name2",
                    Stars = "Stars2",
                    NumberOfRooms = 0,
                    NumberOfFloors = 1,
                    Address = "Address2",
                    Phone = "Phone2"
                },
                new Hotel
                {
                    Id = HotelIdForDelete,
                    Name = "Name3",
                    Stars = "Stars3",
                    NumberOfRooms = 0,
                    NumberOfFloors = 1,
                    Address = "Address3",
                    Phone = "Phone3"
                },
                new Hotel
                {
                    Id = HotelIdForUpdate,
                    Name = "Name4",
                    Stars = "Stars4",
                    NumberOfRooms = 0,
                    NumberOfFloors = 1,
                    Address = "Address4",
                    Phone = "Phone4"
                });
            context.Rooms.AddRange(
                new Room
                {
                    Id = Guid.Parse("0542185A-7DD7-4CC7-9245-6CE2A439A737"),
                    HotelId = HotelIdForUpdate,
                    Number = "1",
                    Floor = 1,
                    Cost = 1,
                    Area = 1,
                    RoomCategory = "Категорія1",
                    ServicesAndAmenities = "Сервіси1",
                    WindowsView = "Вид з вікна1",
                    BookingState = "Вільний",
                    BookingDates = string.Empty
                },
                new Room
                {
                    Id = Guid.Parse("E5897075-AD06-4969-8B36-E791ED77C65A"),
                    HotelId = HotelIdForUpdate,
                    Number = "2",
                    Floor = 2,
                    Cost = 2,
                    Area = 2,
                    RoomCategory = "Категорія2",
                    ServicesAndAmenities = "Сервіси2",
                    WindowsView = "Вид з вікна2",
                    BookingState = "Вільний",
                    BookingDates = string.Empty
                },
                new Room
                {
                    Id = RoomIdForDelete,
                    HotelId = HotelIdForUpdate,
                    Number = "3",
                    Floor = 3,
                    Cost = 3,
                    Area = 3,
                    RoomCategory = "Категорія3",
                    ServicesAndAmenities = "Сервіси3",
                    WindowsView = "Вид з вікна3",
                    BookingState = "Вільний",
                    BookingDates = string.Empty
                },
                new Room
                {
                    Id = RoomIdForUpdate,
                    HotelId = HotelIdForUpdate,
                    Number = "4",
                    Floor = 4,
                    Cost = 4,
                    Area = 4,
                    RoomCategory = "Категорія4",
                    ServicesAndAmenities = "Сервіси4",
                    WindowsView = "Вид з вікна4",
                    BookingState = "Вільний",
                    BookingDates = string.Empty
                });
            context.Customers.AddRange(
                new Customer
                {
                    Id = Guid.Parse("DBB62C43-1EAF-46A5-B2B9-0658A5668EE7"),
                    RoomId = RoomIdForUpdate,
                    Name = "Name1",
                    Surname = "Surname1",
                    Patronymic = "Patronymic1",
                    Passport = "Passport1",
                    Gender = "Gender1",
                    BirthDate = DateTime.Today,
                    Phone = "Phone1",
                    Email = "Email1"
                },
                new Customer
                {
                    Id = Guid.Parse("5C8AFB2C-BA2A-419D-930E-0AD0207DC187"),
                    RoomId = RoomIdForUpdate,
                    Name = "Name2",
                    Surname = "Surname2",
                    Patronymic = "Patronymic2",
                    Passport = "Passport2",
                    Gender = "Gender2",
                    BirthDate = DateTime.Today,
                    Phone = "Phone2",
                    Email = "Email2"
                },
                new Customer
                {
                    Id = CustomerIdForDelete,
                    RoomId = RoomIdForUpdate,
                    Name = "Name3",
                    Surname = "Surname3",
                    Patronymic = "Patronymic3",
                    Passport = "Passport3",
                    Gender = "Gender3",
                    BirthDate = DateTime.Today,
                    Phone = "Phone3",
                    Email = "Email3"
                },
                new Customer
                {
                    Id = CustomerIdForUpdate,
                    RoomId = RoomIdForUpdate,
                    Name = "Name4",
                    Surname = "Surname4",
                    Patronymic = "Patronymic4",
                    Passport = "Passport4",
                    Gender = "Gender4",
                    BirthDate = DateTime.Today,
                    Phone = "Phone4",
                    Email = "Email4"
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(DatabaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
