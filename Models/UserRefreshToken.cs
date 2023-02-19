using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class UserRefreshToken
{
    public int UserRefreshTokenId { get; set; }

    public string? Token { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string? IpAddress { get; set; }

    public bool IsInvalidated { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
