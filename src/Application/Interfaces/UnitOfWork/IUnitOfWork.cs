using Application.Interfaces.Repositories;

namespace Application.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IJobRepository JobRepository { get; }
    public ICompanyJobRepository CompanyJobRepository { get; }
    public ICompanyRepository CompanyRepository { get; }
    public IApplicationRepository ApplicationRepository { get; }
    public IResumeRepository ResumeRepository { get; }
    public ISkillRepository SkillRepository { get; }
    public IApplicantSkillRepository ApplicantSkillRepository { get; }
    public IExperienceRepository ExperienceRepository { get; }

    Task<int> CommitAsync();
}