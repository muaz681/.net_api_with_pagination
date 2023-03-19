namespace FinalApi.StoreProcedure
{
    public interface IConfigManager
    {
        string ERP_APPS { get; }
        string Muaz_Security { get; }
        string GetConnectionString(string connectionName);
    }
}
