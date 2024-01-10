using Application.Interfaces.Repositories;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicantSkillRepository(ApplicationDbContext dbContext)
    : GenericRepository<ApplicantSkill>(dbContext), IApplicantSkillRepository
{
}
