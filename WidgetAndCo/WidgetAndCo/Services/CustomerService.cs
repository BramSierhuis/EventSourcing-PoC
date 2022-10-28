using WidgetAndCo.Extensions;
using WidgetAndCo.Infrastructure;
using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.Requests;

namespace WidgetAndCo.Services;

public class CustomerService : ICustomerService
{
    private readonly IMessageBusFactory _busFactory;
    private const string QueueName = "customerqueue";

    public CustomerService(IMessageBusFactory busFactory)
    {
        _busFactory = busFactory;
    }
    
    public async Task CreateCustomer(CreateCustomerRequest request)
    {
        var command = new CreateCustomer()
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task ChangeFirstName(ChangeFirstNameRequest request, Guid customerId)
    {
        var command = new ChangeCustomerFirstName()
        {
            AggregateId = customerId,
            FirstName = request.FirstName
        };

        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }
    public async Task ChangeLastName(ChangeLastNameRequest request, Guid customerId)
    {
        var command = new ChangeCustomerLastName()
        {
            AggregateId = customerId,
            LastName = request.LastName
        };

        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }
}