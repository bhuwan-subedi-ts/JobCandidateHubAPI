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

        /// <summary>
        /// Insert or Update Candidate information into DB
        /// </summary>
        /// <param name="candidateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpsertCandidate([FromBody] CandidateDto candidateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _candidateService.UpsertCandidate(candidateDto);

            return Ok(result);
        }
        /// <summary>
        /// List all the candidates from the Database table
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> GetCandidatesList()
        {
            var result = await _candidateService.GetCandidatesList();
            return Ok(result);
        }
    }
}
