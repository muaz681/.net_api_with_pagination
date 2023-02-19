using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblZonePermission
{
    public int IntId { get; set; }

    public int? IntEmployeeId { get; set; }

    public int? IntZone { get; set; }

    public int? IntLevel { get; set; }

    public bool? YsnActive { get; set; }

    public int? IntInsertBy { get; set; }
}
