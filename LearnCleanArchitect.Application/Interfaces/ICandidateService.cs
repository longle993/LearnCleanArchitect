using LearnCleanArchitect.Application.Candidates.Commands.AddCandidates;
using LearnCleanArchitect.Application.Candidates.Commands.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCleanArchitect.Application.Interfaces
{
    public interface ICandidateService
    {
        Task<Guid> AddCandidate(AddCandidateCommand request, CancellationToken ct);
        Task<List<CandidateDto>> GetCandidates(GetCandidatesQuery request, CancellationToken ct);
    }
}
