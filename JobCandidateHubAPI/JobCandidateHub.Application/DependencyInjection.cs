using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using JobCandidateHub.Application.Interfaces;
using JobCandidateHub.Application.Services;
using Microsoft.AspNetCore.Hosting;


namespace JobCandidateHub.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<ICandidateService, CandidateService>();
            return services;
        }
    }
}
