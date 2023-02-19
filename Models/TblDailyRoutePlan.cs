using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblDailyRoutePlan
{
    public long IntId { get; set; }

    public int IntEmployeeId { get; set; }

    public DateTime DteDate { get; set; }

    public int IntRetailerId { get; set; }

    public bool? YsnVisited { get; set; }

    public DateTime? DteVisitedTime { get; set; }

    public int? IntDayId { get; set; }
}
