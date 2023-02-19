namespace FinalApi.StoreProcedure
{
    public interface IConfigManager
    {
        string ERP_APPS { get; }

        string GetConnectionString(string connectionName);
    }
}
