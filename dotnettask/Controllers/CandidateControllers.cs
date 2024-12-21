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

        
    }
}
