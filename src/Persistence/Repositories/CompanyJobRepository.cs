using Application.Interfaces.Repositories;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyJobRepository : GenericRepository<CompanyJob>, ICompanyJobRepository
{
    public CompanyJobRepository(ApplicationDbContext context) : base(context)
    {
    }
}
