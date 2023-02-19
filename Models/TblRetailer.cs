using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblRetailer
{
    public int IntId { get; set; }

    public string? StrRetailer { get; set; }

    public int? IntMarketId { get; set; }

    public int? IntTerritory { get; set; }

    public int? IntUnit { get; set; }

    public decimal? DecLat { get; set; }

    public decimal? DecLon { get; set; }

    public string? StrAddress { get; set; }

    public string? StrProprietor { get; set; }

    public string? StrContactNo { get; set; }

    public int? IntInsertBy { get; set; }

    public DateTime? InsertDate { get; set; }

    public string? StrType { get; set; }

    public string? StrMarketName { get; set; }

    public string? StrLatLon { get; set; }

    public int? IntDistributor { get; set; }

    public string? StrManager { get; set; }

    public string? StrManagerContact { get; set; }

    public bool? YsnActive { get; set; }
}
