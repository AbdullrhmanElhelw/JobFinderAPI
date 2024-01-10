using Application.Interfaces.Repositories;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SkillRepository(ApplicationDbContext context)
    : GenericRepository<Skill>(context), ISkillRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task AddRangeAsync(IEnumerable<Skill> skills)
    {
        await _context.Skills.AddRangeAsync(skills);
    }
}
