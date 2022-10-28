namespace WidgetAndCo.Infrastructure;

public interface IMessageBusFactory
{
    IMessageBus GetClient(string queueName);
}