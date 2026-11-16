using LearnCleanArchitect.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCleanArchitect.Application.Candidates.Commands.AddCandidates
{
    public record AddCandidateCommand(string FirstName, string LastName, DateOnly BirthDay, string Address, string PhoneNumber, string Email, int Status) : IRequest<Guid>;
    public sealed class AddCandidateCommandHandler(ICandidateService service) : IRequestHandler<AddCandidateCommand, Guid>
    {
        public Task<Guid> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
           => service.AddCandidate(request, cancellationToken);
    }
}
