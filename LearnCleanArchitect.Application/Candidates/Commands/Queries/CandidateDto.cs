using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCleanArchitect.Application.Candidates.Commands.Queries
{
    public record CandidateDto(Guid Id, string FirstName, string LastName, DateOnly BirthDay, string Address, string PhoneNumber, string Email, int Status);
}
