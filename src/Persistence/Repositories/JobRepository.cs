using Application.Interfaces.Repositories;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class JobRepository : GenericRepository<Job>, IJobRepository
{
    public JobRepository(ApplicationDbContext context) : base(context)
    {
    }
}