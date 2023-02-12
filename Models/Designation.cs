using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class Designation
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long GradeId { get; set; }

    public long CafeteriaGradeId { get; set; }

    public bool IsBelowManager { get; set; }

    public bool? IsActive { get; set; }

    public long LastActionBy { get; set; }

    public DateTime LastActionDate { get; set; }
}
