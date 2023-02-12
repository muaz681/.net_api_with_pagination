using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class Division
{
    public int Id { get; set; }

    public string DivisionName { get; set; } = null!;

    public string DivisionNameBn { get; set; } = null!;

    public string Url { get; set; } = null!;
}
