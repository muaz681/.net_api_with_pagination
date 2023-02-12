using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class Enquiry
{
    public long Id { get; set; }

    public long BuyerId { get; set; }

    public long AgentId { get; set; }

    public long CategoryId { get; set; }

    public long StyleId { get; set; }

    public decimal Quantity { get; set; }

    public DateTime ShipmentDate { get; set; }

    public long SeasonId { get; set; }

    public decimal OfferPrice { get; set; }

    public int CurrencyId { get; set; }

    public decimal Cmprice { get; set; }

    public long ContentId { get; set; }

    public long SupplierId { get; set; }

    public string AccessoriesTrims { get; set; } = null!;

    public string PrintingEmbroidery { get; set; } = null!;

    public string WashingDyeing { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string RefNo { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime LastActionDate { get; set; }

    public long LastActionBy { get; set; }

    public bool? IsActive { get; set; }
}
