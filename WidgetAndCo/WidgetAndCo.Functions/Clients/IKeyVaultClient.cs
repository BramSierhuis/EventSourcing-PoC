namespace WidgetAndCo.Clients;

public interface IKeyVaultClient
{
    public string GetKey(string name);
}