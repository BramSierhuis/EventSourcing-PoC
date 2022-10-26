using System.ComponentModel.DataAnnotations.Schema;
using WidgetAndCo.Messages.Events;

namespace WidgetAndCo.Models;

public class Stream
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public int Version { get; set; }
    public ICollection<StreamEvent> Events { get; set; }
}

public class StreamEvent
{
    public string Data { get; set; }
    public string Type { get; set; }
    public string ClrType { get; set; }
}