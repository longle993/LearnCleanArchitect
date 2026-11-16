using LearnCleanArchitect.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCleanArchitect.Domain.Entities
{
    public class Candidate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDay { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Status Status { get; set; }
    }
}
