using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblShopSign
{
    public int SignId { get; set; }

    public int? UnitId { get; set; }

    public DateTime? EntryDate { get; set; }

    public int? EntryBy { get; set; }

    public bool? IsActive { get; set; }

    public int? ShopId { get; set; }

    public byte[]? Img { get; set; }

    public string? Remarks { get; set; }

    public string? SignAddress { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Lon { get; set; }
}
