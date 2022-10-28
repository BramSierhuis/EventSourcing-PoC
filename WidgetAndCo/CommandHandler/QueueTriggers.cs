using CommandHandler.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WidgetAndCo.Models;

namespace CommandHandler;

public class QueueTriggers
{
    private readonly ICustomerHandler _customerHandler;
    private readonly IProductHandler _productHandler;
    private readonly IOrderHandler _orderHandler;

    public QueueTriggers(IProductHandler productHandler, IOrderHandler orderHandler, ICustomerHandler customerHandler)
    {
        _productHandler = productHandler;
        _orderHandler = orderHandler;
        _customerHandler = customerHandler;
    }

    [Function("CustomerQueueTrigger")]
    public async Task CustomerQueueTrigger([ServiceBusTrigger("customerqueue", Connection = "ServiceBusConnection")] string myQueueItem, FunctionContext context)
    {
        var command = GetCommand(myQueueItem);
        await _customerHandler.Handle(command);
    }
    
    [Function("OrderQueueTrigger")]
    public async Task OrderQueueTrigger([ServiceBusTrigger("orderqueue", Connection = "ServiceBusConnection")] string myQueueItem, FunctionContext context)
    {
        var command = GetCommand(myQueueItem);
        await _orderHandler.Handle(command);
    }

    [Function("ProductQueueTrigger")]
    public async Task ProductQueueTrigger([ServiceBusTrigger("productqueue", Connection = "ServiceBusConnection")] string myQueueItem, FunctionContext context)
    {
        var command = GetCommand(myQueueItem);
        await _productHandler.Handle(command);
    }

    private static object GetCommand(string message)
    {
        var queueItem = JsonConvert.DeserializeObject<QueueItem>(message);
        var datatype = Type.GetType(queueItem.ClrType);
        return JsonConvert.DeserializeObject(queueItem.Command.ToString(), datatype);   
    }
}