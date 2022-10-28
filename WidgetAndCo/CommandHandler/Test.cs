// using CommandHandler.Services;
// using Microsoft.Azure.Functions.Worker;
//
// namespace CommandHandler;
//
// public class Test
// {
//     private readonly ICustomerHandler _customerHandler;
//     private readonly IProductHandler _productHandler;
//     private readonly IOrderHandler _orderHandler;
//
//     public Test(IProductHandler productHandler, IOrderHandler orderHandler, ICustomerHandler customerHandler)
//     {
//         _productHandler = productHandler;
//         _orderHandler = orderHandler;
//         _customerHandler = customerHandler;
//     }
//
//     [Function("tester")]
//     public async Task Tester([ServiceBusTrigger("customerqueue", Connection = "ServiceBusConnection2")] string myQueueItem, FunctionContext context)
//     {
//         var v = 5;
//     }
// }