namespace CommandHandler.Handlers.Abstract;

public interface IHandler
{
    Task Handle(object command);
}