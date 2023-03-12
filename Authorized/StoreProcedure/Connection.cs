namespace FinalApi.Authorized.StoreProcedure
{
    public class Connection
    {
        private static string GetConnection()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetDirectoryRoot(@"\"))
           .AddJsonFile("appSettings.json", true)
           .Build();
            var connString = config.GetSection("ConnectionStrings").Value;
            return connString;
        }
    }
}
