using FinalApi.Data;
using FinalApi.IServices.ISProcedure;
using FinalApi.Models.SPModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinalApi.Service.StoredProcedureService
{
    public class SPAEmployeService: ISPEmployeJob
    {
        private readonly ERP_HR_Context _context;
        public SPAEmployeService(ERP_HR_Context context)
        {
            _context = context;
        }

        public async Task<DataTable> GetJobStation(int intJobStationID)
        {

            DataTable dt = new DataTable();

            try
            {
                var connection = new SqlConnection("Data Source=10.24.50.119;Initial Catalog=ERP_HR;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;TrustServerCertificate=true;ApplicationIntent=ReadWrite;");
                using (connection)
                {
                    string sql = "[dbo].[sprEmployeeByJobStation]";
                    using (SqlCommand sqlcmd = new SqlCommand(sql, connection))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@intLoginId", intJobStationID);
                        connection.Open();

                        using (SqlDataAdapter sqlAdaptar = new SqlDataAdapter(sqlcmd))
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
    }
}
