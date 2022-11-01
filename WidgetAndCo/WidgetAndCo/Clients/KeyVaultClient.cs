using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace WidgetAndCo.Clients;

public class KeyVaultClient : IKeyVaultClient
{
    private readonly SecretClient _client;

    public KeyVaultClient(IConfiguration configuration)
    {
        var keyVaultName = configuration.GetSection("KeyVaultName").Value 
                           ?? throw new ArgumentNullException("KeyVaultName not found in configuration");
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