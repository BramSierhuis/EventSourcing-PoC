using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;

namespace WidgetAndCo.Clients;

public class BlobClient : IProductImageClient
{
    public async Task AddAsync(string containerName, byte[] image, string fileName)
    {
        var connection = "";
        
        var blobContainerClient = new BlobContainerClient(connection, containerName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        using var ms = new MemoryStream(image, false);
        await blobClient.UploadAsync(ms);
    }
    
    public Uri GetUri(string containerName, string fileName)
    {
        var connection = "";
        
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