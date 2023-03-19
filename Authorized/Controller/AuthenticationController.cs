using FinalApi.Authorized.IServices;
using FinalApi.Authorized.Models;
using FinalApi.Authorized.Models.SP;
using FinalApi.Helper;
using FinalApi.Models;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlTypes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinalApi.Authorized.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private MessageStatus _messageStatus;
        public AuthenticationController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [HttpPost]
        [Route("registration")]
        public async Task<MessageStatus> CreateUser(string firstName, string lastName, string email, string password, string conPassword, DateTime dob, string uniqID, string softID, string tokenID)
        {
            try
            {
                DataTable result = await _authServices.Register(firstName, lastName, email, password, conPassword, dob, uniqID, softID, tokenID);
                if(result.Rows.Count > 0)
                {
                    string output = JsonConvert.SerializeObject(result);
                    List<UserRegistration> data = JsonConvert.DeserializeObject<List<UserRegistration>>(output);
                    return _messageStatus = new MessageStatus()
                    {
                        Data = null,
                        Status = true,
                        Code = 200,
                        Message = "Successfull"
                    };
                }
                else
                {
                    return _messageStatus = new MessageStatus()
                    {
                        Data = null,
                        Status = false,
                        Code = 200,
                        Message = "Data Insertation Failed"
                    };
                }
            }
            catch (Exception ex)
            {
                return _messageStatus = new MessageStatus()
                {
                    Data = null,
                    Status = false,
                    Code = 404,
                    Message = "Failed"
                };
            }
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] UserRegistration userRegistration)
        {
            // Connect to the database
            using (var connection = new SqlConnection("Data Source=10.24.50.119;Initial Catalog=Muaz_Security;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;TrustServerCertificate=true;ApplicationIntent=ReadWrite;"))
            {
                connection.Open();

                // Create a command object for the stored procedure
                string sql = "[dbo].[sprAuhtentication]";
                using (var sqlCmd = new SqlCommand(sql, connection))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    
                    sqlCmd.Parameters.AddWithValue("@type", 1);
                    sqlCmd.Parameters.AddWithValue("@strFirstName", userRegistration.firstName);
                    sqlCmd.Parameters.AddWithValue("@strLastName", userRegistration.lastName);
                    sqlCmd.Parameters.AddWithValue("@strEmail", userRegistration.email);
                    sqlCmd.Parameters.AddWithValue("@strPassword", userRegistration.password);
                    sqlCmd.Parameters.AddWithValue("@strConfirmPass", userRegistration.conPassword);
                    sqlCmd.Parameters.AddWithValue("@DOB", userRegistration.dob);
                    sqlCmd.Parameters.AddWithValue("@ysnActive", 1);
                    sqlCmd.Parameters.AddWithValue("@uniqeID", userRegistration.uniqID);
                    sqlCmd.Parameters.AddWithValue("@softwareID", userRegistration.softwareID);
                    sqlCmd.Parameters.AddWithValue("@intRole", 2);
                    sqlCmd.Parameters.AddWithValue("@tokenID", userRegistration.tokenID);

                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var message = reader["strMsg"].ToString();
                            return Ok(message);
                        }
                    }
                }

            }

            // Return a success message
            return Ok("User added successfully");
        }

    }
}
