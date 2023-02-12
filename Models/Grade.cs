using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class Grade
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Basic { get; set; }

    public decimal HouseRent { get; set; }

    public decimal Medical { get; set; }

    public decimal Transport { get; set; }

    public decimal Food { get; set; }

    public decimal Gross { get; set; }

    public bool? IsActive { get; set; }

    public long LastActionBy { get; set; }

    public DateTime LastActionDate { get; set; }
}
