using ViewModels.ObservableModifications;
using System.Text.RegularExpressions;

namespace ViewModels
{
    public class HotelVM : ObservableObject
    {
        // fields
        private string name;
        private string stars;
        private int numberOfRooms;
        private int numberOfFloors;
        private string address;
        private string phone;

        // mapped properties
        public Guid Id { get; set; }
        public List<RoomVM> Rooms { get; set; }

        public string Name
        {
            get => name;
            set { if (name != value) { name = value; OnPropertyChanged(); } }
        }

        public string Stars
        {
            get => stars;
            set { if (stars == value) return; stars = value; OnPropertyChanged(); }
        }

        public int NumberOfRooms
        {
            get => numberOfRooms;
            set { if (numberOfRooms != value) { numberOfRooms = value; OnPropertyChanged(); } }
        }

        public int NumberOfFloors
        {
            get => numberOfFloors;
            set
            {
                if (!int.TryParse(value.ToString(), out numberOfFloors) && value != 0)
                    throw new ArgumentException("Введіть у числовому вигляді!");
                OnPropertyChanged(ref numberOfFloors, value);
            }
        }

        public string Address
        {
            get => address;
            set { if (address != value) { address = value; OnPropertyChanged(); } }
        }

        public string Phone
        {
            get => phone;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { phone = string.Empty; return; }
                if (!new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$").IsMatch(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Неправильний формат номера телефону!");
                OnPropertyChanged(ref phone, value);
            }
        }

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
