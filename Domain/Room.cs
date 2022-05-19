namespace Domain
{
    public class Room
    {
        // Mapped properties
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public double Cost { get; set; }
        public double Area { get; set; }
        public string RoomCategory { get; set; }
        public string ServicesAndAmenities { get; set; }
        public string WindowsView { get; set; }
        public string BookingState { get; set; }
        public DateTime? BookingStartDate { get; set; }
        public DateTime? BookingEndDate { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public Customer Customer { get; set; }
    }
}
