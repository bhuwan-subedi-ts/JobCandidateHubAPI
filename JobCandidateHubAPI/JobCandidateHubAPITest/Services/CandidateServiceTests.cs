using Moq;
using AutoMapper;
using JobCandidateHub.Application.Services;
using JobCandidateHub.Domain.Entities;
using JobCandidateHub.Domain.Interfaces;
using JobCandidateHub.Application.DTO;

namespace JobCandidateHubAPI.Tests.Services
{
    [TestFixture]
    public class CandidateServiceTests
    {
        private CandidateService _candidateService;
        private Mock<ICandidateRepository> _candidateRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _mapperMock = new Mock<IMapper>();
            _candidateService = new CandidateService(_candidateRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task AddOrUpdateCandidate_ShouldAddCandidate_WhenNewCandidate()
        {
            var candidateDto = new CandidateDto { Email = "test@example.com", FirstName = "John", LastName = "Doe" };
            var candidateEntity = new Candidate { Email = "test@example.com", FirstName = "John", LastName = "Doe" };

            _mapperMock.Setup(m => m.Map<Candidate>(candidateDto)).Returns(candidateEntity);
            _mapperMock.Setup(m => m.Map<CandidateDto>(It.IsAny<Candidate>())).Returns(candidateDto);

            var result = await _candidateService.UpsertCandidate(candidateDto);

            Assert.IsNotNull(result);
            Assert.AreEqual(candidateDto.Email, result.Email);
        }
    }
}
