using Azure.Messaging.ServiceBus;
using CommandHandler.Repositories;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.Requests;

namespace CommandHandler.Services;

public class CustomerService : ICustomerService
{
    private readonly ServiceBusClient _bus;

    public CustomerService(ServiceBusClient bus)
    {
        _bus = bus;
    }

    public async Task Handle(object command) => await Handle((dynamic)command);

    private async Task Handle(CreateCustomerRequest request)
    {
        var createCustomer = new CreateCustomer()
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        
        await _bus.
    }

    private async Task Handle(ChangeCustomerFirstName cmd)
    {
        var customer = await _store.Load(cmd.AggregateId);

        customer.Handle(cmd);
        
        await _store.Save(customer);
    }
    private async Task Handle(ChangeCustomerLastName cmd)
    {
        var customer = await _store.Load(cmd.AggregateId);

        customer.Handle(cmd);
        
        await _store.Save(customer);
    }
}