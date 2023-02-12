using System;
using System.Collections.Generic;

namespace FinalApi.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string ContactNo { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool IsSalaryHold { get; set; }

    public string Nid { get; set; } = null!;

    public string ParmanentAddress { get; set; } = null!;

    public string PresentAddress { get; set; } = null!;

    public long DesignationId { get; set; }

    public long DepartmetId { get; set; }

    public long JobStationId { get; set; }

    public long UnitId { get; set; }

    public string GuardianName { get; set; } = null!;

    public string GuardianContactNo { get; set; } = null!;

    public string GuardianAddress { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public DateTime JoiningDate { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Email { get; set; } = null!;

    public long JobTypeId { get; set; }

    public string PunchCardNo { get; set; } = null!;

    public long SupervisorId { get; set; }

    public int GenderId { get; set; }

    public int ReligionId { get; set; }

    public DateTime LastActionDate { get; set; }

    public long LastActionBy { get; set; }
}
