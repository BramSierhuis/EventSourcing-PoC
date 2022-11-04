using Microsoft.AspNetCore.Mvc;
using WidgetAndCo.Exceptions;
using WidgetAndCo.Extensions;
using WidgetAndCo.Infrastructure;
using WidgetAndCo.Models.Commands;
using WidgetAndCo.Models.Commands.Customers;
using WidgetAndCo.Models.ReadModels;
using WidgetAndCo.Models.Requests;
using WidgetAndCo.Models.Requests.Customers;
using WidgetAndCo.Repositories;
using WidgetAndCo.Repositories.Abstract;
using WidgetAndCo.Services.Abstract;

namespace WidgetAndCo.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMessageBusFactory _busFactory;
    private const string QueueName = "customerqueue";

    public CustomerService(IMessageBusFactory busFactory, ICustomerRepository customerRepository)
    {
        _busFactory = busFactory;
        _customerRepository = customerRepository;
    }
    
    public async Task CreateCustomer(CreateCustomerRequest request)
    {
        var command = new CreateCustomer()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            ShippingAddress = request.ShippingAddress
        };

        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task ChangeFirstName(ChangeFirstNameRequest request, Guid customerId)
    {
        if (! await _customerRepository.Exists(customerId)) throw new CustomerNotFoundException();
        var command = new ChangeCustomerFirstName()
        {
            AggregateId = customerId,
            FirstName = request.FirstName
        };

        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }
    public async Task ChangeLastName(ChangeLastNameRequest request, Guid customerId)
    {
        if (! await _customerRepository.Exists(customerId)) throw new CustomerNotFoundException();
        var command = new ChangeCustomerLastName()
        {
            AggregateId = customerId,
            LastName = request.LastName
        };

        await _busFactory.GetClient(QueueName).PublishMessageAsync(command.GetQueueItem());
    }

    public async Task<IEnumerable<CustomerReadModel>> GetAll()
    {
        return await _customerRepository.GetAll();
    }

    public async Task<CustomerReadModel> GetById(Guid customerId)
    {
        var customer = await _customerRepository.TryGetById(customerId);
        if (customer == null) throw new CustomerNotFoundException();
        return customer;
    }
}