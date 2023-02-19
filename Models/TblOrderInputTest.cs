using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class TblOrderInputTest
{
    public long Intid { get; set; }

    public int? Intunitid { get; set; }

    public long? IntOrderNumber { get; set; }

    public int? IntCustid { get; set; }

    public string? StrDepot { get; set; }

    public int? Intproductid { get; set; }

    public decimal? MonQty { get; set; }

    public decimal? Monprice { get; set; }

    public decimal? OrderAmount { get; set; }

    public DateTime? DteOrderDate { get; set; }

    public int? InsertBy { get; set; }

    public DateTime? DteInsertdate { get; set; }

    public bool? Ysnactive { get; set; }

    public string? StrRemarks { get; set; }

    public DateTime? DteUpdateDate { get; set; }

    public int? IntUpdateBy { get; set; }

    public DateTime? DteDeliveryDate { get; set; }
}
