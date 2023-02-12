using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class JobStation
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long UnitId { get; set; }

    public string Address { get; set; } = null!;

    public long TypeId { get; set; }

    public bool IsRoster { get; set; }

    public bool? IsActive { get; set; }

    public long LastActionBy { get; set; }

    public DateTime LastActionDate { get; set; }
}
