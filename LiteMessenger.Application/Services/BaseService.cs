using LiteMessenger.Domain.Interfaces;
using LiteMessenger.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LiteMessenger.Application.Services;

public class BaseService<T> : IBaseService<T>
    where T : BaseEntity
{
    public LiteMessengerContext context { get; }

    public BaseService(LiteMessengerContext context)
    {
        this.context = context;
    }

    public async Task<T> CreateAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await context.Set<T>().FirstOrDefaultAsync(r => r.Id == id);

        if (entity != null)
            context.Remove(entity);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetAsync(string id)
    {
        return await context.Set<T>().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity != null)
            context.Set<T>().Update(entity);

        await context.SaveChangesAsync();
    }
}
