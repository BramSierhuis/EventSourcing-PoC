using WidgetAndCo.Models;
using WidgetAndCo.Models.Commands;

namespace WidgetAndCo.Extensions;

public static class CommandExtensions
{
    public static QueueItem GetQueueItem(this ICommand command) => new QueueItem()
    {
        ClrType = command.GetType().AssemblyQualifiedName ?? throw new InvalidOperationException(),
        Command = command
    };
}