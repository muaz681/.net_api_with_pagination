using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class MenuPermission
{
    public long Id { get; set; }

    public long EmployeeId { get; set; }

    public long MenuId { get; set; }

    public bool View { get; set; }

    public bool Edit { get; set; }

    public bool Delete { get; set; }

    public bool Create { get; set; }

    public bool? IsActive { get; set; }

    public long LastActionBy { get; set; }

    public DateTime LastActionDate { get; set; }
}
