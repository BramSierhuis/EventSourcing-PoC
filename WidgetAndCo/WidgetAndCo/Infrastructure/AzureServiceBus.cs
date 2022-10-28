using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace WidgetAndCo.Infrastructure;

internal class AzureServiceBus : IMessageBus
{
    private readonly ServiceBusSender _serviceBusSender;

    internal AzureServiceBus(ServiceBusSender serviceBusSender)
    {
        _serviceBusSender = serviceBusSender;
    }

    public async Task PublishMessageAsync<T>(T message)
    {
        var jsonString = JsonConvert.SerializeObject(message);

        var serviceBusMessage = new ServiceBusMessage(jsonString);

        await _serviceBusSender.SendMessageAsync(serviceBusMessage);
    }

    internal static IMessageBus Create(ServiceBusSender sender)
    {
        return new AzureServiceBus(sender);
    }
}