using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; } = new List<UserRefreshToken>();
}
