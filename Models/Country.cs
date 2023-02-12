using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Iso { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string NickName { get; set; } = null!;

    public string Iso3 { get; set; } = null!;

    public short Numcode { get; set; }

    public int PhoneCode { get; set; }
}
