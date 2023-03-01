using FinalApi.Models.SPModels;
using System.Collections;
using System.Data;

namespace FinalApi.IServices.ISProcedure
{
    public interface ISPEmployeJob
    {
        public Task<DataTable> GetJobStation(int pageSize, int pageNumber, int intJobStationID);
        
    }
}
