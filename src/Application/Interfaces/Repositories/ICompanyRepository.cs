using Domain.Common.IdentityUsers;

namespace Application.Interfaces.Repositories;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(int id);
}
