using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class District
{
    public int Id { get; set; }

    public int DivisionId { get; set; }

    public string DistrictName { get; set; } = null!;

    public string DistrictNameBn { get; set; } = null!;

    public decimal Lat { get; set; }

    public decimal Lon { get; set; }

    public string Url { get; set; } = null!;
}
