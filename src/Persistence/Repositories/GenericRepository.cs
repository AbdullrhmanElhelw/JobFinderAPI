using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class GenericRepository<TModel>(ApplicationDbContext context)
    : IGenericRepository<TModel> where TModel : class
{
    private readonly ApplicationDbContext _context = context;
    public async Task<TModel> AddAsync(TModel entity)
    {
        await _context.Set<TModel>().AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(TModel entity)
    {
        await Task.Run(() => _context.Entry(entity).State = EntityState.Deleted);
    }

    public async Task<IReadOnlyList<TModel>> GetAllAsync()
    {
        return await _context
            .Set<TModel>()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<TModel>> GetAsync(Expression<Func<TModel, bool>> expression)
    {
        return await _context
             .Set<TModel>()
             .Where(expression)
             .ToListAsync();
    }

    public async Task<TModel?> GetByIdAsync(int id)
    {
        return await _context.Set<TModel>().FindAsync(id);
    }

    public void UpdateAsync(TModel entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
}
