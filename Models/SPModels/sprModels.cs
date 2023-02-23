using System;
namespace FinalApi.Models.SPModels
{
    public class sprModels
    {
        public int intID { get; set; }
        public string strRetailer { get; set; }
        public int intTerritory { get; set; }
        public string strUnit { get; set; }
        public string strAddress { get; set; }
        public string strProprietor { get; set; }
        public string strContactNo { get; set; }

        public decimal? lat { get; set; }
        public decimal? lon { get; set; }
        public string strManager { get; set; }
        public string strManagerContact { get; set; }
        public string strMarketName { get; set; }
        public string territory { get; set; }
    }

    public class AddInputOrder
    {
        public int intID { get; set; }
        public int intCustomerID { get; set; }
        public int intProductID { get; set; }
        public string StrProductName { get; set; }
        public int intQuantity { get; set; }
        public decimal? decUnitPrice { get; set; }
        public decimal? decTotalPrice { get; set; }
        public decimal? decDiscountRate { get; set; }
        public decimal? decPriceAfterDiscount { get; set; }
        public decimal? decDiscountAmount { get; set; }
        public decimal? decSpecialDiscountRate { get; set; }
        public decimal? decSpecialDiscountAmount { get; set; }
    }
   
}
