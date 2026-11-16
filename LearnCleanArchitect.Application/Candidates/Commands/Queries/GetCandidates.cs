using LearnCleanArchitect.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace LearnCleanArchitect.Application.Candidates.Commands.Queries
{
    public record GetCandidatesQuery() : IRequest<List<CandidateDto>>;
    public sealed class GetCandidates (ICandidateService service) : IRequestHandler<GetCandidatesQuery, List<CandidateDto>>
    {
        public Task<List<CandidateDto>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
            => service.GetCandidates(request, cancellationToken);
    }
}
