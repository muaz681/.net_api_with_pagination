using FinalApi.Models.SPModels;
using System.Collections;
using System.Data;

namespace FinalApi.IServices.ISProcedure
{
    public interface ISPEmployeJob
    {
        public Task<DataTable> GetJobStation(int intJobStationID, int pageSize, int pageNumber);

    }
}
