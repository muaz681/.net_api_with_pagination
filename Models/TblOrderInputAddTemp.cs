using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblOrderInputAddTemp
{
    public int IntId { get; set; }

    public int? IntCustomerId { get; set; }

    public int? IntProductId { get; set; }

    public string? StrProductName { get; set; }

    public int? IntQuantity { get; set; }

    public decimal? DecUnitPrice { get; set; }

    public decimal? DecTotalPrice { get; set; }

    public decimal? DecDiscountRate { get; set; }

    public decimal? DecDiscountAmount { get; set; }

    public decimal? DecSpecialDiscountRate { get; set; }

    public decimal? DecSpecialDiscountAmount { get; set; }

    public decimal? DecPriceAfterDiscount { get; set; }

    public int? IntInsertBy { get; set; }

    public bool? YsnActive { get; set; }

    public bool? YsnPosted { get; set; }

    public DateTime? DteInsDate { get; set; }

    public int? IntUnitId { get; set; }

    public int? IntShippingPointId { get; set; }

    public string? StrShippingPointName { get; set; }
}
