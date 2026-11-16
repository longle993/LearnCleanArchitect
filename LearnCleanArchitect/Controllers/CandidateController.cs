using LearnCleanArchitect.Application.Candidates.Commands.AddCandidates;
using LearnCleanArchitect.Application.Candidates.Commands.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnCleanArchitect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ISender _sender;
        public CandidateController(ISender sender) => _sender = sender;

        [HttpPost]
        public async Task<IActionResult> AddCandidate(AddCandidateRequest request, CancellationToken ct)
        {
            var id = await _sender.Send(new AddCandidateCommand(request.FirstName, request.LastName, request.BirthDay, request.Address, request.PhoneNumber, request.Email, request.Status), ct);
            return CreatedAtAction(nameof(GetCandidates), new {id});
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidates(CancellationToken ct)
        {
            var candidates = await _sender.Send(new GetCandidatesQuery(), ct);
            return Ok(candidates);
        }

        public record AddCandidateRequest(
            string FirstName,
            string LastName,
            DateOnly BirthDay,
            string Address,
            string PhoneNumber,
            string Email,
            int Status
        );
    }
}
