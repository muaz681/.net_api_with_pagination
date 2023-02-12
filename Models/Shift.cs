using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class Shift
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime LatePunchTime { get; set; }

    public DateTime LastPunchTime { get; set; }

    public long JobStationId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime LastActionDate { get; set; }

    public long LastActionBy { get; set; }
}
