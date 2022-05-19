using ViewModels.ObservableModifications;
using System.Text.RegularExpressions;

namespace ViewModels
{
    public class CustomerVM : ObservableObject
    {
        // fields
        private string name;
        private string surname;
        private string patronymic;
        private string gender;
        private string passport;
        private DateTime? birthDate;
        private string phone;
        private string email;

        // mapped properties
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public RoomVM Room { get; set; }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { name = string.Empty; return; }
                if (!new Regex(@"^([А-ЯІЄЇЁ]{1}[а-яієїё]{1,23}|[A-Z]{1}[a-z]{1,23})$").IsMatch(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Неправильний формат імені!");
                OnPropertyChanged(ref name, value);
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { surname = string.Empty; return; }
                if (!new Regex(@"^([А-ЯІЄЇЁ]{1}[а-яієїё]{1,23}|[A-Z]{1}[a-z]{1,23})$").IsMatch(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Неправильний формат прізвища!");
                OnPropertyChanged(ref surname, value);
            }
        }

        public string Patronymic
        {
            get => patronymic;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { patronymic = string.Empty; return; }
                if (!new Regex(@"^([А-ЯІЄЇЁ]{1}[а-яієїё]{1,23}|[A-Z]{1}[a-z]{1,23})$").IsMatch(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Неправильний формат ім'я по батькові!");
                OnPropertyChanged(ref patronymic, value);
            }
        }

        public string Gender
        {
            get => gender;
            set { if (gender != value) { gender = value; OnPropertyChanged(); } }
        }

        public string Passport
        {
            get => passport;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { passport = string.Empty; return; }
                if (!new Regex(@"^[А-ЯA-Z0-9 ]+$").IsMatch(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Неправильний формат паспорта!");
                OnPropertyChanged(ref passport, value);
            }
        }

        public DateTime? BirthDate
        {
            get
            {
                if (birthDate != DateTime.MinValue) return birthDate;
                return null;
            }
            set { if (birthDate != value) { birthDate = value; OnPropertyChanged(); } }
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

        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { email = string.Empty; return; }
                if (!new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$").IsMatch(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Неправильний формат електронної адреси!");
                OnPropertyChanged(ref email, value);
            }
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}" +
                $"\nСтать: {Gender.ToLower()}" +
                $"\nПаспорт: {Passport}" +
                $"\nДата народження: {birthDate.Value.ToShortDateString()} року" +
                $"\nТелефон: {Phone}" +
                $"\nEmail: {Email}";
        }
    }
}
