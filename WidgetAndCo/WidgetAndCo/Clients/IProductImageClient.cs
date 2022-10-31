namespace WidgetAndCo.Clients;

public interface IProductImageClient
{
    Task AddAsync(string containerName, byte[] image, string fileName);
    Uri GetUri(string containerName, string fileName);
}