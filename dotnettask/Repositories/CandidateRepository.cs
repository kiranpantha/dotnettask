namespace CandidateHubAPI.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly string _connectionString;

        public CandidateRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
    }
}
