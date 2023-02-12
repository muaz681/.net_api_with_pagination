using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class BusinessUnit
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Bin { get; set; } = null!;

    public string Tin { get; set; } = null!;

    public string Irc { get; set; } = null!;

    public string Code { get; set; } = null!;

    public long SalaryAccountId { get; set; }

    public bool? IsActive { get; set; }

    public long LastActionBy { get; set; }

    public DateTime LastActionDate { get; set; }
}
