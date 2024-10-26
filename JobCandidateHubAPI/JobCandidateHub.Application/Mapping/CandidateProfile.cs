using AutoMapper;
using JobCandidateHub.Application.DTO;
using JobCandidateHub.Domain.Entities;

namespace JobCandidateHub.Application.Mapping
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();
        }
    }
}
