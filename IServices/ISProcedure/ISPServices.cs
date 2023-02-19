using FinalApi.Models;
using FinalApi.Models.SPModels;
using System.Data;

namespace FinalApi.IServices.ISProcedure
{
    public interface ISPServices
    {
        public Task<DataTable> getShippingPoint(int typeID, int enrollID);
        //public Task<IEnumerable<sprModels>> GetProductByIdAsync(int enrollID);
    }
}
