namespace ViewModels
{
    public class CustomerVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Passport { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid RoomId { get; set; }
        public RoomVM Room { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}" +
                $"\nСтать: {Gender.ToLower()}" +
                $"\nПаспорт: {Passport}" +
                $"\nДата народження: {BirthDate.ToShortDateString()} року" +
                $"\nТелефон: {Phone}" +
                $"\nEmail: {Email}";
        }
    }
}
