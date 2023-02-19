using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblAppVersionControl
{
    public int IntId { get; set; }

    public string? StrVersion { get; set; }

    public DateTime? DteLaunchDate { get; set; }

    public int? IntLaunchBy { get; set; }

    public string? StrUrl { get; set; }

    public bool? YsnActive { get; set; }
}
