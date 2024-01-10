using Application.Interfaces.Repositories;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ResumeRepository(ApplicationDbContext dbContext)
    : GenericRepository<Resume>(dbContext), IResumeRepository
{

}
