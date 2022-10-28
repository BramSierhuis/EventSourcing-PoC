using WidgetAndCo.Infrastructure;

namespace WidgetAndCo.Extensions;

public static class AzureServiceBusExtensions
{
    public static IServiceCollection AddAzureServiceBusFactory(this IServiceCollection services)
    {
        services.AddSingleton<IMessageBusFactory, AzureServiceBusFactory>();
        return services;
    }
}