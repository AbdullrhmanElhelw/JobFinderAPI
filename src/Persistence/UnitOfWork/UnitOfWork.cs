using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWork;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.UnitOfWork;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;

    public IJobRepository JobRepository { get; private set; } = new JobRepository(context);

    public ICompanyJobRepository CompanyJobRepository { get; private set; } = new CompanyJobRepository(context);

    public ICompanyRepository CompanyRepository { get; private set; } = new CompanyRepository(context);

    public IApplicationRepository ApplicationRepository { get; private set; } = new ApplicationRepository(context);

    public IResumeRepository ResumeRepository { get; private set; } = new ResumeRepository(context);

    public ISkillRepository SkillRepository { get; private set; } = new SkillRepository(context);

    public IApplicantSkillRepository ApplicantSkillRepository { get; private set; } = new ApplicantSkillRepository(context);

    public IExperienceRepository ExperienceRepository { get; private set; } = new ExperienceRepository(context);

    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}