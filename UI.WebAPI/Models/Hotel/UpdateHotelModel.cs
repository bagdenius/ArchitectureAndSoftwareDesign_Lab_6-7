namespace UI.WebAPI.Models.Hotel
{
    public class UpdateHotelModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Stars { get; set; }
        public int NumberOfFloors { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
