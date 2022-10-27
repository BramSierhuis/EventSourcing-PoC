using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;
using WidgetAndCo.Functions.Projections;
using Stream = WidgetAndCo.Models.Stream;

namespace WidgetAndCo.Functions;

public class EventStoreTrigger
{
    private readonly IEnumerable<IProjection> _projections;

    public EventStoreTrigger(IEnumerable<IProjection> projections)
    {
        _projections = projections;
    }

    [Function("EventStoreTrigger")]
    public async Task Run([CosmosDBTrigger(
            databaseName: "EventStore",
            collectionName: "Streams",
            ConnectionStringSetting = "CosmosDbConnectionString",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true)]
        IReadOnlyList<Stream> input, FunctionContext context)
    {
        var events = new List<object>();

        foreach (var stream in input)
        {
            foreach (var streamEvent in stream.Events)
            {
                var datatype = Type.GetType(streamEvent.ClrType);
                var data = JsonConvert.DeserializeObject(streamEvent.Data, datatype);

                events.Add(data ?? throw new Exception("Encountered streamEvent without eventdata"));
            }
        }

        foreach (var projection in _projections)
        {
            await projection.Handle(events);
        }
    }
}
