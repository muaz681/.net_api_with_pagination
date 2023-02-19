using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblEmployeeRemoteAttendance
{
    public int IntAutoIncrement { get; set; }

    public int IntEmployeeId { get; set; }

    public int? IntJobStationId { get; set; }

    public DateTime DteAttendanceDate { get; set; }

    public TimeSpan DteAttendanceTime { get; set; }

    public string? StrUserIp { get; set; }

    public bool? YsnProcess { get; set; }

    public string? StrRemark { get; set; }

    public decimal DecLat { get; set; }

    public decimal DecLon { get; set; }
}
