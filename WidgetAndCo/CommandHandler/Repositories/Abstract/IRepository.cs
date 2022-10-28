using System.Linq.Expressions;
using Stream = WidgetAndCo.Models.Stream;

namespace CommandHandler.Repositories.Abstract;

public interface IRepository<T> where T : Stream
{
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    Task<T> Add(T entity);
    Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);
    Task RemoveAsync(T entity);
    Task RemoveAsync(Guid id);
    Task RemoveRange(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
}