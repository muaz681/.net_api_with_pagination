﻿using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class JobStationType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public long LastActionBy { get; set; }

    public DateTime LastActionDate { get; set; }
}