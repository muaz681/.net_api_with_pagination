using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblShopSignStatus
{
    public int AutoId { get; set; }

    public int? SignId { get; set; }

    public DateTime? Date { get; set; }

    public int? CheckedBy { get; set; }

    public bool? IsUsable { get; set; }

    public string? Remarks { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsActive { get; set; }

    public byte[]? Image { get; set; }
}
