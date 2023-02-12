using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class SupplierProfile
{
    public long Id { get; set; }

    public int UnitId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierCode { get; set; } = null!;

    public long CountryId { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime LastActionDate { get; set; }

    public long LastActionBy { get; set; }
}
