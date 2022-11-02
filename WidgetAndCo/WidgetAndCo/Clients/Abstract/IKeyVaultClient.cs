namespace WidgetAndCo.Clients.Abstract;

public interface IKeyVaultClient
{
    public string GetKey(string name);
}