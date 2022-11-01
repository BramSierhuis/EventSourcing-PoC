namespace CommandHandler.Clients;

public interface IKeyVaultClient
{
    public string GetKey(string name);
}