using Application.Interfaces.Repositories;
using Domain.Models;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationRepository(ApplicationDbContext dbContext) :
    GenericRepository<ApplicantJob>(dbContext), IApplicationRepository
{

}

