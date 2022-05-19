﻿using MediatR;

namespace Queries.ResumeCommands.UpdateResume
{
    public class UpdateCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public string Passport { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
