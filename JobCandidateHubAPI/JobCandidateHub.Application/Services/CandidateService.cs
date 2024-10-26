using JobCandidateHub.Application.DTO;
using JobCandidateHub.Application.Interfaces;
using JobCandidateHub.Domain.Entities;
using JobCandidateHub.Domain.Interfaces;
using AutoMapper;


namespace JobCandidateHub.Application.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<Candidate> UpsertCandidate(CandidateDto candidateDto)
        {
            var candidate = await _candidateRepository.GetByEmailAsync(candidateDto.Email);

            if (candidate == null)
            {
                candidate = _mapper.Map<Candidate>(candidateDto);
                await _candidateRepository.AddAsync(candidate);
            }
            else
            {
                _mapper.Map(candidateDto, candidate);
                await _candidateRepository.UpdateAsync(candidate);
            }

            return candidate;
        }
        public async Task<List<Candidate>> GetCandidatesList()
        {
            var candidates = await _candidateRepository.GetAllAsync();
            if(candidates.Count > 0)
            {
                return candidates;
            }
            return new List<Candidate> { };
        }
    }
}
