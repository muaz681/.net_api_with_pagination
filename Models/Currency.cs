using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string Currency1 { get; set; } = null!;

    public string CurrencyShort { get; set; } = null!;

    public decimal _1Bdt { get; set; }

    public decimal ConversionToBdt { get; set; }

    public string CurrencySign { get; set; } = null!;

    public string ContinentName { get; set; } = null!;

    public DateTime LastUpdateDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public bool? IsActive { get; set; }
}
