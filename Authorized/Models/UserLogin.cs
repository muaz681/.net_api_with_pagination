using System;
using System.Collections.Generic;

namespace FinalApi.Authorized.Models;

public partial class UserLogin
{
    public int IntId { get; set; }

    public string StrFirstName { get; set; } = null!;

    public string? StrLastName { get; set; }

    public string StrEmail { get; set; } = null!;

    public byte[] StrPassword { get; set; } = null!;

    public byte[] StrConfirmPass { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public DateTime? DtAccOpen { get; set; }

    public bool? YsnActive { get; set; }

    public string? UniqeId { get; set; }

    public string? SoftwareId { get; set; }

    public int? IntRole { get; set; }

    public string? TokenId { get; set; }
}
