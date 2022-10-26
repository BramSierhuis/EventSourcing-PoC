using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WidgetAndCo.Aggregates;
using WidgetAndCo.Context;
using WidgetAndCo.Extensions;
using WidgetAndCo.Models;
using Stream = WidgetAndCo.Models.Stream;

namespace WidgetAndCo.Repositories;

public class EventStore<T> : IAggregateStore<T> where T : AggregateRoot
{
    private readonly EventStoreContext _context;

    public EventStore(EventStoreContext context)
    {
        _context = context;
    }

    public Task<bool> Exists(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public async Task Save(T aggregate)
    {
        var events = aggregate.GetEvents()
            .Select(@event =>
                new StreamEvent()
                {
                    ClrType = @event.GetType().AssemblyQualifiedName,
                    //Id = Guid.NewGuid(),
                    Data = JsonConvert.SerializeObject(@event),
                    Type = @event.GetType().Name
                }).ToList();

        var stream = new Stream()
        {
            Type = aggregate.GetType().Name,
            Id = aggregate.AggregateId,
            Events = events,
            Version = aggregate.Version
        };

        var _ = await Add(stream);
        //var _ = await UpdateAsync(stream);
        
        aggregate.Flush();
    }

    public async Task<T> Load(Guid aggregateId)
    {
        var aggregate = (T) Activator.CreateInstance(typeof(T), true);

        var result = await Find(x => x.Id == aggregateId);

        if (result.Count() > 1) throw new Exception();

        var events = result.First().Events;
        
         aggregate.Hydrate(events.Select(e =>
         {
             var datatype = Type.GetType(e.ClrType);
             var data = JsonConvert.DeserializeObject(e.Data, datatype);
        
             return data;
         }));

        return aggregate;
    }
    
    private async Task<Stream> Add(Stream entity)
    {
        _context.Set<Stream>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<IEnumerable<Stream>> Find(Expression<Func<Stream, bool>> expression)
    {
        return await _context.Set<Stream>().Where(expression).ToListAsync();
    }
    
    public async Task<IEnumerable<Stream>> GetAll()
    {
        return await _context.Set<Stream>().ToListAsync();
    }
    
    public async Task<Stream> GetById(Guid id)
    {
        return await _context.Set<Stream>().FindAsync(id);
    }

    public async Task<Stream> UpdateAsync(Stream stream)
    {
        try
        {
            var currentStream = await _context.Set<Stream>().AsNoTracking().Where(x => x.Id == stream.Id)
                .FirstOrDefaultAsync();
            var updatedEntity = (Stream)currentStream.GetUpdatedObject(stream);

            _context.Set<Stream>().Update(updatedEntity);
        }
        catch (Exception e)
        {
            _context.Set<Stream>().Add(stream);
        }

        await _context.SaveChangesAsync();
        return stream;
    }
}