using CandidateHubAPI.Models;

namespace CandidateHubAPI.Repositories
{
    public interface ICandidateRepository
    {
        Task<string> AddOrUpdateCandidateAsync(Candidate candidate);
    }
}