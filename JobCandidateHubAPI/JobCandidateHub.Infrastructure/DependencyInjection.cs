using JobCandidateHub.Domain.Interfaces;
using JobCandidateHub.Infrastructure.Data;
using JobCandidateHub.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using JobCandidateHub.Application.Mapping;


namespace JobCandidateHub.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddAutoMapper(cfg =>
                cfg.AddMaps(Assembly.GetAssembly(typeof(CandidateProfile))));
            return services;
        }
    }
}
