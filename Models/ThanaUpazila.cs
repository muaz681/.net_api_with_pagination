using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class ThanaUpazila
{
    public int Id { get; set; }

    public int DistrictId { get; set; }

    public string ThanaUpazilaName { get; set; } = null!;

    public string ThanaUpazilaNameBn { get; set; } = null!;

    public decimal Lat { get; set; }

    public decimal Lon { get; set; }

    public string Url { get; set; } = null!;
}
