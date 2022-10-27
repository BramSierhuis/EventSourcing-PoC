namespace WidgetAndCo.Functions.Projections;

public interface IProjection
{
    //public Task Handle(IEnumerable<object> events);
    public Task Handle(IEnumerable<object> events);
}