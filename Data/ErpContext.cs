using System;
using System.Collections.Generic;
using FinalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalApi.Data;

public partial class ErpContext : DbContext
{
    public ErpContext()
    {
    }

    public ErpContext(DbContextOptions<ErpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgentProfile> AgentProfiles { get; set; }

    public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }

    public virtual DbSet<BuyerProfile> BuyerProfiles { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Enquiry> Enquiries { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<JobStation> JobStations { get; set; }

    public virtual DbSet<JobStationType> JobStationTypes { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<MenuPermission> MenuPermissions { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftConfig> ShiftConfigs { get; set; }

    public virtual DbSet<SupplierProfile> SupplierProfiles { get; set; }

    public virtual DbSet<ThanaUpazila> ThanaUpazilas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.24.50.119;Initial Catalog=ERP;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;Integrated Security=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgentProfile>(entity =>
        {
            entity.ToTable("AgentProfile", "snd");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AgentCode).HasMaxLength(50);
            entity.Property(e => e.AgentName).HasMaxLength(200);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhoneNo).HasMaxLength(20);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<BusinessUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeUnit");

            entity.ToTable("BusinessUnit", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Bin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BIN");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Irc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IRC");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SalaryAccountId).HasColumnName("SalaryAccountID");
            entity.Property(e => e.Tin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TIN");
        });

        modelBuilder.Entity<BuyerProfile>(entity =>
        {
            entity.ToTable("BuyerProfile", "snd");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BuyerCode).HasMaxLength(50);
            entity.Property(e => e.BuyerName).HasMaxLength(200);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhoneNo).HasMaxLength(20);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country", "gbl");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Iso)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISO");
            entity.Property(e => e.Iso3)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISO3");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NickName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency", "gbl");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContinentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConversionToBdt)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("ConversionToBDT");
            entity.Property(e => e.Currency1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Currency");
            entity.Property(e => e.CurrencyShort)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CurrencySign).HasMaxLength(5);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastUpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e._1Bdt)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("1 BDT =");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeDepartment");

            entity.ToTable("Department", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeDesignation");

            entity.ToTable("Designation", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CafeteriaGradeId).HasColumnName("CafeteriaGradeID");
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.ToTable("District", "gbl");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DistrictNameBn).HasMaxLength(50);
            entity.Property(e => e.DivisionId).HasColumnName("DivisionID");
            entity.Property(e => e.Lat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Lon).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.ToTable("Division", "gbl");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DivisionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DivisionNameBn).HasMaxLength(50);
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Employees");

            entity.ToTable("Employee", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppointmentDate).HasColumnType("date");
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.ContactNo).HasMaxLength(20);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.DepartmetId).HasColumnName("DepartmetID");
            entity.Property(e => e.DesignationId).HasColumnName("DesignationID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GuardianAddress).HasMaxLength(200);
            entity.Property(e => e.GuardianContactNo).HasMaxLength(30);
            entity.Property(e => e.GuardianName).HasMaxLength(100);
            entity.Property(e => e.ImagePath).HasMaxLength(100);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.JobStationId).HasColumnName("JobStationID");
            entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");
            entity.Property(e => e.JoiningDate).HasColumnType("date");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Nid)
                .HasMaxLength(30)
                .HasColumnName("NID");
            entity.Property(e => e.ParmanentAddress).HasMaxLength(200);
            entity.Property(e => e.PresentAddress).HasMaxLength(200);
            entity.Property(e => e.PunchCardNo).HasMaxLength(100);
            entity.Property(e => e.ReligionId).HasColumnName("ReligionID");
            entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<Enquiry>(entity =>
        {
            entity.ToTable("Enquiry", "snd");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccessoriesTrims)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.BuyerId).HasColumnName("BuyerID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Cmprice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("CMPrice");
            entity.Property(e => e.ContentId).HasColumnName("ContentID");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OfferPrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PrintingEmbroidery)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.RefNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ShipmentDate).HasColumnType("datetime");
            entity.Property(e => e.StyleId).HasColumnName("StyleID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.WashingDyeing)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeGender");

            entity.ToTable("Gender", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sn1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SN1");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeGrade");

            entity.ToTable("Grade", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Basic).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Food).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Gross).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.HouseRent).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Medical).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Transport).HasColumnType("decimal(18, 4)");
        });

        modelBuilder.Entity<JobStation>(entity =>
        {
            entity.ToTable("JobStation", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<JobStationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeJobStationType");

            entity.ToTable("JobStationType", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.ToTable("JobType", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.JobTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<MenuPermission>(entity =>
        {
            entity.ToTable("MenuPermission", "rns");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeReligion");

            entity.ToTable("Religion", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.ToTable("Shift", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.JobStationId).HasColumnName("JobStationID");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastPunchTime).HasColumnType("datetime");
            entity.Property(e => e.LatePunchTime).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ShiftConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeShiftConfig");

            entity.ToTable("ShiftConfig", "hrm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
        });

        modelBuilder.Entity<SupplierProfile>(entity =>
        {
            entity.ToTable("SupplierProfile", "scm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhoneNo).HasMaxLength(20);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.SupplierCode).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(200);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<ThanaUpazila>(entity =>
        {
            entity.ToTable("ThanaUpazila", "gbl");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.Lat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Lon).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.ThanaUpazilaName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ThanaUpazilaNameBn).HasMaxLength(50);
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
