namespace WidgetAndCo.Infrastructure;

public interface IMessageBus
{
    Task PublishMessageAsync<T>(T message);
}