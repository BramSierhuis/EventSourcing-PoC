using System.Linq.Expressions;
using CommandHandler.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Models;
using Stream = WidgetAndCo.Models.Stream;

namespace CommandHandler.Repositories;

public class EventStore<T> : IAggregateStore<T> where T : AggregateRoot
{
    private readonly EventStoreContext _context;

    public EventStore(EventStoreContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public Task<bool> Exists(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public async Task Save(T aggregate)
    {
        var events = aggregate.GetUncommittedEvents()
            .Select(@event =>
                new StreamEvent()
                {
                    ClrType = @event.GetType().AssemblyQualifiedName ?? throw new ArgumentException("Invalid event"),
                    Data = JsonConvert.SerializeObject(@event)
                }).ToList();

        var stream = new Stream()
        {
            Id = Guid.NewGuid(),
            AggregateId = aggregate.AggregateId,
            Type = aggregate.GetType().Name,
            Version = aggregate.Version,
            Events = events
        };

        var _ = await Add(stream);
        
        aggregate.Flush();
    }

    public async Task<T> Load(Guid aggregateId)
    {
        var aggregate = (T) Activator.CreateInstance(typeof(T), true);

        var result = (await Find(x => x.AggregateId == aggregateId)).ToList();

        var events = new List<StreamEvent>();
        foreach (var stream in result)
        {
            events.AddRange(stream.Events);
        }
        
         
        aggregate.Hydrate(events.Select(e =>
         {
             var datatype = Type.GetType(e.ClrType);
             var data = JsonConvert.DeserializeObject(e.Data, datatype);
        
             return data;
         }));

        return aggregate;
    }
    
    private async Task<IEnumerable<Stream>> Find(Expression<Func<Stream, bool>> expression)
    {
        return await _context.Set<Stream>().Where(expression).ToListAsync();
    }
    
    private async Task<Stream> Add(Stream newStream)
    {
        _context.Set<Stream>().Add(newStream);
        await _context.SaveChangesAsync();

        return newStream;
    }
}