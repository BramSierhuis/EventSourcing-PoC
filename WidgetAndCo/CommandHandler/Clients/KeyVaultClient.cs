using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace CommandHandler.Clients;

public class KeyVaultClient : IKeyVaultClient
{
    private readonly SecretClient _client;

    public KeyVaultClient()
    {
        var keyVaultName = Environment.GetEnvironmentVariable("KeyVaultName")
                           ?? throw new ArgumentNullException("KeyVaultName not found in environment");
        var keyVaultLocation = new Uri($"https://{keyVaultName}.vault.azure.net");

        _client = new SecretClient(keyVaultLocation, new DefaultAzureCredential());
    }
    
    public string GetKey(string name)
    {
        var secret = _client.GetSecret(name) 
                     ?? throw new ArgumentNullException("Secret not found");
        
        return secret.Value.Value;
    }
}