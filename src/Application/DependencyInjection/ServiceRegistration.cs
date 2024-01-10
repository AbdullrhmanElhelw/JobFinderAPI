using Application.Behaviors;
using Application.DapperQueries;
using Application.DapperQueries.AdminQueries;
using Application.DapperQueries.ApplicantQueries;
using Application.DapperQueries.ApplicantResumeQueries;
using Application.DapperQueries.ApplicantSkillQueries;
using Application.DapperQueries.CompanyQueries;
using Application.DapperQueries.EmployerQueries;
using Application.DapperQueries.ExperienceQueries;
using Application.DapperQueries.JobQueries;
using Application.DapperQueries.ResumeQueries;
using Application.DapperQueries.SKillQueries;
using Application.EmailServices;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() }, includeInternalTypes: true);

        services.AddSingleton<DapperDbContext>();
        services.AddScoped<IJobQuery, JobQuery>();
        services.AddScoped<ICompanyQuery, CompanyQuery>();
        services.AddScoped<IApplicantQuery, ApplicantQuery>();
        services.AddScoped<IApplicantSkillQuery, ApplicantSkillQuery>();
        services.AddScoped<IResumeQuery, ResumeQuery>();
        services.AddScoped<ISkillQuery, SkillQuery>();
        services.AddScoped<IEmployerQuery, EmployerQuery>();
        services.AddScoped<IApplicantResume, ApplicantResume>();
        services.AddScoped<IAdminQuery, AdminQuery>();
        services.AddScoped<IExperienceQuery, ExperienceQuery>();
        services.AddTransient<IEmailService, EmailService>();
        return services;
    }
}