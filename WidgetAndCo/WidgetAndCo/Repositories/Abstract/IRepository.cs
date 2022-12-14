using System.Linq.Expressions;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Repositories;

public interface IRepository<T> where T : ReadModel
{
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    Task<bool> Exists(Guid id);
    Task<T?> TryGetById(Guid id);
}