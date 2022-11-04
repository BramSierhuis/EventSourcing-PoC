using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using WidgetAndCo.Clients.Abstract;

namespace WidgetAndCo.Clients;

public class BlobClient : IProductImageClient
{
    private readonly IConfiguration _configuration;

    public BlobClient(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task AddAsync(string containerName, byte[] image, string fileName)
    {
        var connection = _configuration.GetValue<string>("StorageConnectionString");
        
        var blobContainerClient = new BlobContainerClient(connection, containerName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        using var ms = new MemoryStream(image, false);
        await blobClient.UploadAsync(ms);
    }
    
    public Uri GetUri(string containerName, string fileName)
    {
        var connection = _configuration.GetValue<string>("StorageConnectionString");
        
        var blobContainerClient = new BlobContainerClient(connection, containerName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        var sasBuilder = new BlobSasBuilder()
        {
            BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
            BlobName = blobClient.Name,
            Resource = "b"
        };
        
        sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
        sasBuilder.SetPermissions(BlobSasPermissions.Read |
                                  BlobSasPermissions.Write);

        return blobClient.GenerateSasUri(sasBuilder);
    }
}