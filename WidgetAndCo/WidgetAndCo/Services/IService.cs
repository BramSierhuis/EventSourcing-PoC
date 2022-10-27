namespace WidgetAndCo.Services;

public interface IService
{
    Task Handle(object command);
}