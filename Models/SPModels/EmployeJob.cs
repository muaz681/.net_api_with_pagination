using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinalApi.Models.SPModels
{
    public class EmployeJob
    {
        //public int intJobStationID { get; set; }
        public string strEmployeeName { get; set; }
        public string strEmployeeCode { get; set; }
    }
}
