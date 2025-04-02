using LiteMessenger.Domain.Models;

namespace LiteMessenger.Domain.Interfaces.Services;

public interface IBaseService<T>
    where T : class
{
    Task<T?> GetAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}
