namespace ViewModels
{
    public class HotelVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Stars { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<RoomVM> Rooms { get; set; }

        public override string ToString()
        {
            return $"{Stars} готель \"{Name}\"" +
                $"\nАдреса: {Address}" +
                $"\nТелефон: {Phone}" +
                $"\nКількість поверхів: {NumberOfFloors}" +
                $"\nКількість номерів: {NumberOfRooms}";
        }
    }
}
