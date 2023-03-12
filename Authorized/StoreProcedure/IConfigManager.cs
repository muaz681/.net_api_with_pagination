namespace FinalApi.Authorized.StoreProcedure
{
    public interface IConfigManager
    {
        string Muaz_Security { get; }

        string GetConnectionString(string connectionName);
    }
}
