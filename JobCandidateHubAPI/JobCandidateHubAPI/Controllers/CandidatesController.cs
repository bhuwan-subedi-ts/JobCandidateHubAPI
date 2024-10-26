using JobCandidateHub.Application.DTO;
using JobCandidateHub.Application.Interfaces;
using JobCandidateHub.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly AppDbContext _context;
        public CandidatesController(ICandidateService candidateService, AppDbContext context)
        {
            _candidateService = candidateService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCandidate([FromBody] CandidateDto candidateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _candidateService.UpsertCandidate(candidateDto);

            return Ok(result);
        }
        [HttpGet("test")]
        public IActionResult TestDatabaseConnection()
        {
            var count = _context.Candidates.Count();
            return Ok(new { Count = count });
        }
    }
}
