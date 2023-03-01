using FinalApi.Helper;
using FinalApi.IServices.ISProcedure;
using FinalApi.Models.SPModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System;
using Microsoft.Data.SqlClient;
using FinalApi.Models;
using LiteDB;
using System.Data.SqlTypes;

namespace FinalApi.Controllers.StoreProcedure
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeJobController : ControllerBase
    {
        private readonly ISPEmployeJob _ispEMployeJob;
        private MessageStatus _messageStatus;
        public EmployeJobController(ISPEmployeJob ispEMployeJob)
        {
            _ispEMployeJob = ispEMployeJob;
        }
        [HttpGet]
        [Route("employeJob")]
        public async Task<MessageStatus> GetJobStation(int pageSize, int pageNumber, int intJobStationID)
        {
            try
            {
                DataTable result = await _ispEMployeJob.GetJobStation(pageSize, pageNumber, intJobStationID);
                if (result.Rows.Count > 0)
                {
                    string output = JsonConvert.SerializeObject(result);
                    List<EmployeJob> dataPermission = JsonConvert.DeserializeObject<List<EmployeJob>>(output);
                    _messageStatus = new MessageStatus()
                    {
                        Data = dataPermission,
                        Status = true,
                        Code = 200,
                        Message = "Successful"
                    };
                }
                else
                {
                    _messageStatus = new MessageStatus()
                    {
                        Data = null,
                        Status = true,
                        Code = 200,
                        Message = "Your Data is null"
                    };
                }
            }
            catch (Exception ex)
            {
                _messageStatus = new MessageStatus()
                {
                    Data = null,
                    Status = false,
                    Code = 404,
                    Message = "Failed"
                };
            }
            return _messageStatus;
        }

        [HttpGet]
        [Route("pegTest")]
        public IActionResult GetProducts(int pageSize, int pageNumber, int intLoginId)
        {
            var connection = new SqlConnection("Data Source=10.24.50.119;Initial Catalog=ERP_HR;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;TrustServerCertificate=true;ApplicationIntent=ReadWrite;");
            using (connection)
            {
                string sql = "[dbo].[sprEmployeeByJobStation]";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = pageNumber;
                command.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<EmployeJob> employejobs = new List<EmployeJob>();
                while (reader.Read())
                {
                    EmployeJob employejob = new EmployeJob();
                    employejob.strEmployeeName = (string)reader["strEmployeeName"];
                    
                    if (reader["strEmployeeCode"] != DBNull.Value)
                    {
                        employejob.strEmployeeCode = (string)reader["strEmployeeCode"];
                    }
                    employejobs.Add(employejob);
                }

                return Ok(employejobs);
            }
        }






    }
}
