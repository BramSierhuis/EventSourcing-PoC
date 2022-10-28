namespace CommandHandler.Services;

public interface IHandler
{
    Task Handle(object command);
}