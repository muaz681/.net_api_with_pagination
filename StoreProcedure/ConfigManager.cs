using Microsoft.Extensions.Configuration;
namespace FinalApi.StoreProcedure
{
    public class ConfigManager: IConfigManager
    {
        private readonly IConfiguration _configuration;
        public ConfigManager(IConfiguration configuration) {
            this._configuration = configuration;
        }
        public string ERP_APPS
        {
            get
            {
                return this._configuration["ConnectionStrings:Apps_Connection"];
                //return this._configuration.GetConnectionString("Apps_Connection");
                //return this._configuration["Data Source=10.24.50.119;Initial Catalog=ERP_APPS;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;"];
            }
        }
        public string Muaz_Security
        {
            get
            {
                return this._configuration["ConnectionStrings:Authentication"];
                //return this._configuration.GetConnectionString("Apps_Connection");
                //return this._configuration["Data Source=10.24.50.119;Initial Catalog=ERP_APPS;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;"];
            }
        }


        public string GetConnectionString(string connectionName)
        {
            return this._configuration.GetConnectionString(connectionName);
        }
    }
}
