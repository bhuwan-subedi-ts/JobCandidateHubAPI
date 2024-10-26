using JobCandidateHub.Domain.Entities;
using JobCandidateHub.Domain.Interfaces;
using JobCandidateHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace JobCandidateHub.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _dbContext;

        public CandidateRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Candidate> GetByEmailAsync(string email)
        {
            return await _dbContext.Candidates.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddAsync(Candidate candidate)
        {
            await _dbContext.Candidates.AddAsync(candidate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            _dbContext.Candidates.Update(candidate);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Candidate>> GetAllAsync()
        {
            return await _dbContext.Candidates.ToListAsync();
        }
    }
}
