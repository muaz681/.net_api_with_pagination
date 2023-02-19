using FinalApi.Helper;
using FinalApi.IServices.ISProcedure;
using FinalApi.Models.SPModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System;
using Microsoft.Data.SqlClient;

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
        public async Task<MessageStatus> GetJobStation(int intJobStationID)
        {
            try
            {
                DataTable result = await _ispEMployeJob.GetJobStation(intJobStationID);
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






    }
}
