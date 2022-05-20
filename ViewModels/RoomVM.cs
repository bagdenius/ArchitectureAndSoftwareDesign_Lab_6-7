namespace ViewModels
{
    public class RoomVM
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public double Cost { get; set; }
        public double Area { get; set; }
        public string RoomCategory { get; set; }
        public string ServicesAndAmenities { get; set; }
        public string WindowsView { get; set; }
        public string BookingState { get; set; }
        public string BookingDates { get; set; }

        public override string ToString()
        {
            return $"Номер {Number}" +
                $"\nТип: {RoomCategory.ToLower()}" +
                $"\nПоверх: {Floor}-ий" +
                $"\nЦіна: {Cost} гривень" +
                $"\nПлоща: {Area} кв.м" +
                $"\nВид з вікна {WindowsView.ToLower()}" +
                $"\nСервіси та послуги: {ServicesAndAmenities.ToLower()}";
        }
    }
}
