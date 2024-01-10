using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface ISkillRepository : IGenericRepository<Skill>
{
    Task AddRangeAsync(IEnumerable<Skill> skills);
}
