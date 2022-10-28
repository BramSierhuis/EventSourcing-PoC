namespace CommandHandler.Services;

public interface IService
{
    Task Handle(object command);
}