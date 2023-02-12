using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class ShiftConfig
{
    public long Id { get; set; }

    public long EmployeeId { get; set; }

    public long ShiftId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime LastActionDate { get; set; }

    public long LastActionBy { get; set; }
}
