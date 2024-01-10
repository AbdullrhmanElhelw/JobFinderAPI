using Application.Interfaces.Repositories;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository
{
}