using FinalApi.Models;
using FinalApi.Models.SPModels;
using System.Data;

namespace FinalApi.IServices.ISProcedure
{
    public interface ISPServices
    {
        public Task<DataTable> getShippingPoint(int typeID, int enrollID);
        public Task<DataTable> addItemService(int custID, int productID, string productName, int quantity, decimal discountRate, decimal specialDiscountRate, int salesType, int uom, int enrollID, int unitID, int intShippingPointID, string strShippingPointID);
    }
}
