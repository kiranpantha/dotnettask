using CandidateHubAPI.Models;
using CandidateHubAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CandidateHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _repository;

        public CandidateController(ICandidateRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCandidate([FromBody] Candidate candidate)
        {
            if (string.IsNullOrEmpty(candidate.Email))
                return BadRequest("Email is required.");
            await _repository.AddOrUpdateCandidateAsync(candidate);
            return Ok("Candidate information added/updated successfully.");
        }
    }
}
