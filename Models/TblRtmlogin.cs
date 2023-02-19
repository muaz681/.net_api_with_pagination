using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblRtmlogin
{
    public int IntId { get; set; }

    public int IntEmployeeId { get; set; }

    public string? StrMail { get; set; }

    public string StrPassword { get; set; } = null!;

    public decimal DecLat { get; set; }

    public decimal DecLon { get; set; }

    public int? IntUserType { get; set; }

    public string? StrArea { get; set; }

    public string? StrDeviceId { get; set; }

    public DateTime? DteExpireDate { get; set; }

    public bool? YsnActive { get; set; }

    public int? IntZone { get; set; }
}
