using CandidateHubAPI.Models;
namespace CandidateHubAPI.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> AddOrUpdateCandidateAsync(Candidate candidate);
    }
}