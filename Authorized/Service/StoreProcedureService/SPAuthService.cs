using FinalApi.Authorized.IServices;
using FinalApi.StoreProcedure;
using LiteDB;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FinalApi.Authorized.Service.StoreProcedureService
{
    public class SPAuthService:IAuthServices
    {
        private readonly IConfigManager _configManager;
        private DataTable dt = new DataTable();
        public SPAuthService(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public async Task<DataTable> Register(string firstName, string lastName, string email, string password, string conPassword, DateTime dob, string uniqID, string softID, string tokenID)
        {
            try
            {
                var connection = new SqlConnection("Data Source=10.24.50.119;Initial Catalog=Muaz_Security;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;TrustServerCertificate=true;ApplicationIntent=ReadWrite;");
                using (connection)
                {
                    string sql = "[dbo].[sprAuhtentication]";
                    using(SqlCommand sqlCmd = new SqlCommand(sql, connection))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@type", 1);
                        sqlCmd.Parameters.AddWithValue("@strFirstName", firstName);
                        sqlCmd.Parameters.AddWithValue("@strLastName", lastName);
                        sqlCmd.Parameters.AddWithValue("@strEmail", email);
                        sqlCmd.Parameters.AddWithValue("@strPassword", password);
                        sqlCmd.Parameters.AddWithValue("@strConfirmPass", conPassword);
                        sqlCmd.Parameters.AddWithValue("@DOB", dob);
                        sqlCmd.Parameters.AddWithValue("@ysnActive", true);
                        sqlCmd.Parameters.AddWithValue("@uniqeID", uniqID);
                        sqlCmd.Parameters.AddWithValue("@softwareID", softID);
                        sqlCmd.Parameters.AddWithValue("@intRole", 2);
                        sqlCmd.Parameters.AddWithValue("@tokenID", tokenID);

                        connection.Open();
                        using(SqlDataAdapter sqlAdaptar = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdaptar.Fill(dt);
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }


        public bool CheckEmailExists(string email)
        {
            using (var conn = new SqlConnection("Data Source=10.24.50.119;Initial Catalog=Muaz_Security;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;TrustServerCertificate=true;ApplicationIntent=ReadWrite;"))
            {
                string sql = "[dbo].[sprAuhtentication]";
                var cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strEmail", email);
                conn.Open();
                return (int)cmd.ExecuteScalar() == 1;
            }
        }


    }
}
