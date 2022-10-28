using System.Collections.Concurrent;
using Azure.Messaging.ServiceBus;

namespace WidgetAndCo.Infrastructure;

public class AzureServiceBusFactory : IMessageBusFactory
{
    private readonly object _lockObject = new();
    private readonly string _connectionString = "Endpoint=sb://eventstorequeue.servicebus.windows.net/;SharedAccessKeyName=SendToQueue;SharedAccessKey=SEVpOFWXCgfdwH5dDwVSbuwhVyzwL2jRC8+Qh3iNv0w=";

    private readonly ConcurrentDictionary<string, ServiceBusClient> _clients = new();
    private readonly ConcurrentDictionary<string, ServiceBusSender> _senders = new();

    public IMessageBus GetClient(string queueName)
    {
        var key = $"{_connectionString}-{queueName}";

        if (_senders.ContainsKey(key) && !_senders[key].IsClosed)
        {
            return AzureServiceBus.Create(_senders[key]);
        }

        var client = GetServiceBusClient();

        lock (_lockObject)
        {
            if (_senders.ContainsKey(key) && _senders[key].IsClosed)
            {
                return AzureServiceBus.Create(_senders[key]);
            }

            var sender = client.CreateSender(queueName);

            _senders[key] = sender;
        }

        return AzureServiceBus.Create(_senders[key]);
    }
    
    protected virtual ServiceBusClient GetServiceBusClient()
    {
        var key = $"{_connectionString}";

        lock (_lockObject)
        {
            if (ClientDoesntExistOrIsClosed(_connectionString))
            {
                var client = new ServiceBusClient(_connectionString, new ServiceBusClientOptions
                {
                    TransportType = ServiceBusTransportType.AmqpTcp
                });

                _clients[key] = client;
            }

            return _clients[key];
        }
    }

    private bool ClientDoesntExistOrIsClosed(string connectionString)
    {
        return !_clients.ContainsKey(connectionString) || _clients[connectionString].IsClosed;
    }
}