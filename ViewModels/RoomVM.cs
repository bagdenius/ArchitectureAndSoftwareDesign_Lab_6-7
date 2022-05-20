using ViewModels.ObservableModifications;

namespace ViewModels
{
    public class RoomVM : ObservableObject
    {
        // fields
        private string number;
        private int floor;
        private double cost;
        private double area;
        private string roomCategory;
        private string servicesAndAmenities;
        private string windowsView;
        private string bookingState;
        private DateTime? bookingStartDate;
        private DateTime? bookingEndDate;

        // mapped properties
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        //public HotelVM Hotel { get; set; }
        //public CustomerVM Customer { get; set; }

        public string Number
        {
            get => number;
            set { if (number != value) { number = value; OnPropertyChanged(); } }
        }

        public int? Floor
        {
            get => floor;
            set { if (floor != value && value != null) { floor = (int)value; OnPropertyChanged(); } }
        }

        public double Cost
        {
            get => cost;
            set { if (cost != value) { cost = value; OnPropertyChanged(); } }
        }

        public double Area
        {
            get => area;
            set { if (area != value) { area = value; OnPropertyChanged(); } }
        }

        public string RoomCategory
        {
            get => roomCategory;
            set { if (roomCategory != value) { roomCategory = value; OnPropertyChanged(); } }
        }

        public string ServicesAndAmenities
        {
            get => servicesAndAmenities;
            set { if (servicesAndAmenities != value) { servicesAndAmenities = value; OnPropertyChanged(); } }
        }

        public string WindowsView
        {
            get => windowsView;
            set { if (windowsView != value) { windowsView = value; OnPropertyChanged(); } }
        }

        public string BookingState
        {
            get => bookingState;
            set { if (bookingState != value) { bookingState = value; OnPropertyChanged(); } }
        }

        public string BookingDates
        {
            get
            {
                if (bookingStartDate == null) return string.Empty;
                return $"{bookingStartDate.Value.ToShortDateString()} - " +
                $"{bookingEndDate.Value.ToShortDateString()}";
            }
        }

        //public DateTime? BookingStartDate
        //{
        //    get
        //    {
        //        if (bookingStartDate != DateTime.MinValue) return bookingStartDate;
        //        return null;
        //    }
        //    set { if (bookingStartDate != value) { bookingStartDate = value; OnPropertyChanged(); } }
        //}

        //public DateTime? BookingEndDate
        //{
        //    get
        //    {
        //        if (bookingEndDate != DateTime.MinValue) return bookingEndDate;
        //        return null;
        //    }
        //    set { if (bookingEndDate != value) { bookingEndDate = value; OnPropertyChanged(); } }
        //}

        //public string Info { get => ToString(); }

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
