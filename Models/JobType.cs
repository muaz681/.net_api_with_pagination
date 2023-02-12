using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class JobType
{
    public long Id { get; set; }

    public string JobTypeName { get; set; } = null!;

    public long LastActionBy { get; set; }

    public DateTime LastActionDate { get; set; }

    public bool? IsActive { get; set; }
}
