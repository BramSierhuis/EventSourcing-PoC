using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Stream = WidgetAndCo.Models.Stream;

namespace WidgetAndCo.Functions;

public static class EventStoreTrigger
{
    [Function("EventStoreTrigger")]
    public static void Run([CosmosDBTrigger(
            databaseName: "EventStore",
            collectionName: "Streams",
            ConnectionStringSetting = "CosmosDbConnectionString",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true)]
        IReadOnlyList<Stream> input, FunctionContext context)
    {
        var logger = context.GetLogger("EventStoreTrigger");
        if (input != null && input.Count > 0)
        {
            logger.LogInformation("Documents modified: " + input.Count);
            logger.LogInformation("First document Id: " + input[0].Id);
        }
    }
}
