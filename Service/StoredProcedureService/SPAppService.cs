using FinalApi.Data;
using FinalApi.IServices.ISProcedure;
using FinalApi.Models;
using FinalApi.Models.SPModels;
using FinalApi.StoreProcedure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlTypes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinalApi.Service.StoredProcedureService
{
    [Serializable]
    public class SPAppService: ISPServices
    {
        private readonly IConfigManager _configuration;
        private readonly ErpAppsContext _dbContext;
        private DataTable dt = new DataTable();
        public SPAppService(IConfigManager configuration, ErpAppsContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        

        public async Task<DataTable> getShippingPoint(int typeID, int enrollID)
        {

            DataTable dt = new DataTable();

            try
            {
                var result = "";
                //var connection = new SqlConnection(_configuration.ERP_APPS);
                var connection = new SqlConnection("Data Source=10.24.50.119;Initial Catalog=ERP_APPS;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;TrustServerCertificate=true;ApplicationIntent=ReadWrite;");
                //var connection = new SqlConnection("Data Source=10.24.50.119;Initial Catalog=ERP_APPS;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;");
                using (connection)
                {
                    string sql = "[dbo].[sprDataByPermission]";
                    using (SqlCommand sqlcmd = new SqlCommand(sql, connection))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@type", typeID);
                        sqlcmd.Parameters.AddWithValue("@enroll", enrollID);

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

       public async Task<DataTable> addItemService(int custID, int productID, string productName, int quantity, decimal discountRate, decimal specialDiscountRate, int salesType, int uom, int enrollID, int unitID, int intShippingPointID, string strShippingPointID)
        {
            DataTable dt = new DataTable();
            try
            {
                var connection = new SqlConnection("Data Source=10.24.50.119;Initial Catalog=ERP_APPS;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;TrustServerCertificate=true;ApplicationIntent=ReadWrite; Trusted_Connection=False;");
                using (connection)
                {
                    string sql = "[dbo].[srpOrderInput]";
                    using(SqlCommand sqlcmd = new SqlCommand(sql, connection))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@type", 1);
                        sqlcmd.Parameters.AddWithValue("@custid", custID);
                        sqlcmd.Parameters.AddWithValue("@productid", productID);
                        sqlcmd.Parameters.AddWithValue("@productName", productName);
                        sqlcmd.Parameters.AddWithValue("@quantity", quantity);
                        sqlcmd.Parameters.AddWithValue("@discountrate", discountRate);
                        sqlcmd.Parameters.AddWithValue("@specialDiscountRate", specialDiscountRate);
                        sqlcmd.Parameters.AddWithValue("@salesType", salesType);
                        sqlcmd.Parameters.AddWithValue("@uom", uom);
                        sqlcmd.Parameters.AddWithValue("@enroll", enrollID);
                        sqlcmd.Parameters.AddWithValue("@unitid", unitID);
                        sqlcmd.Parameters.AddWithValue("@intShippintPointID", intShippingPointID);
                        sqlcmd.Parameters.AddWithValue("@strShippingPoint", strShippingPointID);

                        connection.Open();
                        using(SqlDataAdapter sqlAdaptar = new SqlDataAdapter(sqlcmd))
                        {
                            sqlAdaptar.Fill(dt);
                        }
                        connection.Close();
                    }
                }
            }catch(Exception ex)
            {

            }
            return dt;
        }
    }
}
