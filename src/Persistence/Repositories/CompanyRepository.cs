using Application.Interfaces.Repositories;
using Domain.Common.IdentityUsers;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyRepository(ApplicationDbContext context)
    : ICompanyRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Company?> GetByIdAsync(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        return company;
    }
}
