using LearnCleanArchitect.Application.Candidates.Commands.AddCandidates;
using LearnCleanArchitect.Application.Candidates.Commands.Queries;
using LearnCleanArchitect.Application.Interfaces;
using LearnCleanArchitect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace LearnCleanArchitect.Infrastructure.Services
{

    
    public class CandidateService(IAppDbContext context) : ICandidateService
    {
        public async Task<Guid> AddCandidate(AddCandidateCommand request, CancellationToken ct)
        {
            var candidate = new Candidate
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDay = request.BirthDay,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Status = (Domain.Entities.Enums.Status)request.Status
            };

            context.Candidates.Add(candidate);
            await context.SaveChangeAsync(ct);

            return candidate.Id;
        }

        public async Task<List<CandidateDto>> GetCandidates(GetCandidatesQuery request, CancellationToken ct)
        {
            var candidates = await context.Candidates
                .Select(c => new CandidateDto(
                    c.Id,
                    c.FirstName,
                    c.LastName,
                    c.BirthDay,
                    c.Address,
                    c.PhoneNumber,
                    c.Email,
                    (int)c.Status))
                .ToListAsync(ct);
            return candidates;
        }
    }
}
