using JobCandidateHub.Application.DTO;
using JobCandidateHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHub.Application.Interfaces
{
    public interface ICandidateService
    {
        Task<Candidate> UpsertCandidate(CandidateDto candidateDto);
        Task<List<Candidate>> GetCandidatesList();
    }
}
