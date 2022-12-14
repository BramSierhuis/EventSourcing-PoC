using System.ComponentModel.DataAnnotations.Schema;

namespace WidgetAndCo.Models;

public class Stream
{
    public Guid Id { get; set; }
    public Guid AggregateId { get; set; }
    public string Type { get; set; }
    public int Version { get; set; }
    public ICollection<StreamEvent> Events { get; set; }
}