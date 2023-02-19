using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblRealtimeLocation
{
    public int? IntEmployeeId { get; set; }

    public DateTime? DteGrabTime { get; set; }

    public decimal? DecLat { get; set; }

    public decimal? DecLon { get; set; }

    public int? IntNearestReatiler { get; set; }

    public bool? YsnProcessed { get; set; }

    public bool? YsnActive { get; set; }

    public DateTime? DteInsertTime { get; set; }

    public string? StrRemarks { get; set; }
}
