using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace WidgetAndCo.Extensions;

public static class BuilderExtensions
{
    public static void AddKeyVaultSecrets(this WebApplicationBuilder builder)
    {
        var kvName = builder.Configuration.GetValue<string>("KeyVaultName");
        var commerceToolsKeyVaultUri = new Uri($"https://{kvName}.vault.azure.net");
        
        if (commerceToolsKeyVaultUri == null)
            throw new Exception("KeyVault is not correctly configured");
        
        var client = new SecretClient(commerceToolsKeyVaultUri, new DefaultAzureCredential());
        var secrets = client.GetPropertiesOfSecrets().Where(x => x.Enabled == true).ToList();

        var inMemoryCollection = (
            from secret in secrets
            let secretValue = client.GetSecret(secret.Name).Value.Value
            let secretName = secret.Name
            select new KeyValuePair<string, string>(secretName, secretValue)).ToList();

        builder.Configuration.AddInMemoryCollection(inMemoryCollection);
    }
}