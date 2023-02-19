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
   
}
