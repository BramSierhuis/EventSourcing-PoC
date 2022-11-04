using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Functions.Repositories.Abstract;

public interface IRepository<T> where T : ReadModel
{
    Task<T> AddEntity(T entity);
    Task GetAndUpdateEntity(Guid id, Action<T> action);
}