namespace Entities
{
    public class HotelEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Stars { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<RoomEntity> Rooms { get; set; }
    }
}
