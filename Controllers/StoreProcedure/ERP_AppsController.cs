using FinalApi.Helper;
using FinalApi.IServices.ISProcedure;
using FinalApi.Models;
using FinalApi.Models.SPModels;
using FinalApi.Service.StoredProcedureService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace FinalApi.Controllers.StoreProcedure
{
    [Route("api/[controller]")]
    [ApiController]
    public class ERP_AppsController : ControllerBase
    {
        private readonly ISPServices _services;
        private MessageStatus _messageStatus;
        public ERP_AppsController(ISPServices services)
        {
            _services = services;
        }




        //[HttpGet("getproductbyid")]
        //public async Task<IEnumerable<sprModels>> GetProductByIdAsync(int enrollID)
        //{
        //    try
        //    {
        //        var response = await _services.GetProductByIdAsync(enrollID);

        //        if (response == null)
        //        {
        //            return null;
        //        }

        //        return response;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        [HttpGet]
        [Route("DateByPermission")]
        public async Task<MessageStatus> GetDataByPermission(int typeID, int enrollID)
        {
            try
            {
                DataTable result = await _services.getShippingPoint(typeID, enrollID);
                if (result.Rows.Count > 0)
                {
                    string output = JsonConvert.SerializeObject(result);
                    List<sprModels> dataPermission = JsonConvert.DeserializeObject<List<sprModels>>(output);
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
