using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Services.Abstract;

public interface IService<T> where T : ReadModel
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(Guid id);
}