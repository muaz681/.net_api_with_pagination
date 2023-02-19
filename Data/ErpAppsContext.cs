using System;
using System.Collections.Generic;
using FinalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalApi.Data;

public partial class ErpAppsContext : DbContext
{
    public ErpAppsContext()
    {
    }

    public ErpAppsContext(DbContextOptions<ErpAppsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAppVersionControl> TblAppVersionControls { get; set; }

    public virtual DbSet<TblDailyRoutePlan> TblDailyRoutePlans { get; set; }

    public virtual DbSet<TblEmployeeRemoteAttendance> TblEmployeeRemoteAttendances { get; set; }

    public virtual DbSet<TblOrderInputAddTemp> TblOrderInputAddTemps { get; set; }

    public virtual DbSet<TblOrderInputTest> TblOrderInputTests { get; set; }

    public virtual DbSet<TblRealtimeLocation> TblRealtimeLocations { get; set; }

    public virtual DbSet<TblRetailer> TblRetailers { get; set; }

    public virtual DbSet<TblRtmlogin> TblRtmlogins { get; set; }

    public virtual DbSet<TblShopSign> TblShopSigns { get; set; }

    public virtual DbSet<TblShopSignStatus> TblShopSignStatuses { get; set; }

    public virtual DbSet<TblTest> TblTests { get; set; }

    public virtual DbSet<TblZonePermission> TblZonePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=aal-esql01;Initial Catalog=ERP_APPS;User ID=NPrNwUs@Ag;Password=NPa2sLs@Ag;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAppVersionControl>(entity =>
        {
            entity.HasKey(e => e.IntId);

            entity.ToTable("tblAppVersionControl");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteLaunchDate)
                .HasColumnType("datetime")
                .HasColumnName("dteLaunchDate");
            entity.Property(e => e.IntLaunchBy).HasColumnName("intLaunchBy");
            entity.Property(e => e.StrUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("strURL");
            entity.Property(e => e.StrVersion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("strVersion");
            entity.Property(e => e.YsnActive).HasColumnName("ysnActive");
        });

        modelBuilder.Entity<TblDailyRoutePlan>(entity =>
        {
            entity.HasKey(e => e.IntId);

            entity.ToTable("tblDailyRoutePlan");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DteDate)
                .HasColumnType("date")
                .HasColumnName("dteDate");
            entity.Property(e => e.DteVisitedTime)
                .HasColumnType("datetime")
                .HasColumnName("dteVisitedTime");
            entity.Property(e => e.IntDayId).HasColumnName("intDayID");
            entity.Property(e => e.IntEmployeeId).HasColumnName("intEmployeeID");
            entity.Property(e => e.IntRetailerId).HasColumnName("intRetailerId");
            entity.Property(e => e.YsnVisited).HasColumnName("ysnVisited");
        });

        modelBuilder.Entity<TblEmployeeRemoteAttendance>(entity =>
        {
            entity.HasKey(e => e.IntAutoIncrement).IsClustered(false);

            entity.ToTable("tblEmployeeRemoteAttendance");

            entity.Property(e => e.IntAutoIncrement).HasColumnName("intAutoIncrement");
            entity.Property(e => e.DecLat)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("decLat");
            entity.Property(e => e.DecLon)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("decLon");
            entity.Property(e => e.DteAttendanceDate)
                .HasColumnType("date")
                .HasColumnName("dteAttendanceDate");
            entity.Property(e => e.DteAttendanceTime).HasColumnName("dteAttendanceTime");
            entity.Property(e => e.IntEmployeeId).HasColumnName("intEmployeeID");
            entity.Property(e => e.IntJobStationId).HasColumnName("intJobStationID");
            entity.Property(e => e.StrRemark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strRemark");
            entity.Property(e => e.StrUserIp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strUserIP");
            entity.Property(e => e.YsnProcess).HasColumnName("ysnProcess");
        });

        modelBuilder.Entity<TblOrderInputAddTemp>(entity =>
        {
            entity.HasKey(e => e.IntId);

            entity.ToTable("tblOrderInputAddTemp");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DecDiscountAmount)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("decDiscountAmount");
            entity.Property(e => e.DecDiscountRate)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("decDiscountRate");
            entity.Property(e => e.DecPriceAfterDiscount)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("decPriceAfterDiscount");
            entity.Property(e => e.DecSpecialDiscountAmount)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("decSpecialDiscountAmount");
            entity.Property(e => e.DecSpecialDiscountRate)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("decSpecialDiscountRate");
            entity.Property(e => e.DecTotalPrice)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("decTotalPrice");
            entity.Property(e => e.DecUnitPrice)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("decUnitPrice");
            entity.Property(e => e.DteInsDate)
                .HasColumnType("datetime")
                .HasColumnName("dteInsDate");
            entity.Property(e => e.IntCustomerId).HasColumnName("intCustomerID");
            entity.Property(e => e.IntInsertBy).HasColumnName("intInsertBy");
            entity.Property(e => e.IntProductId).HasColumnName("intProductID");
            entity.Property(e => e.IntQuantity).HasColumnName("intQuantity");
            entity.Property(e => e.IntShippingPointId).HasColumnName("intShippingPointId");
            entity.Property(e => e.IntUnitId).HasColumnName("intUnitID");
            entity.Property(e => e.StrProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strProductName");
            entity.Property(e => e.StrShippingPointName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strShippingPointName");
            entity.Property(e => e.YsnActive).HasColumnName("ysnActive");
            entity.Property(e => e.YsnPosted).HasColumnName("ysnPosted");
        });

        modelBuilder.Entity<TblOrderInputTest>(entity =>
        {
            entity.HasKey(e => e.Intid).HasName("PK_tblOrderInput");

            entity.ToTable("tblOrderInputTest");

            entity.Property(e => e.Intid).HasColumnName("intid");
            entity.Property(e => e.DteDeliveryDate)
                .HasColumnType("date")
                .HasColumnName("dteDeliveryDate");
            entity.Property(e => e.DteInsertdate)
                .HasColumnType("datetime")
                .HasColumnName("dteInsertdate");
            entity.Property(e => e.DteOrderDate)
                .HasColumnType("date")
                .HasColumnName("dteOrderDate");
            entity.Property(e => e.DteUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("dteUpdateDate");
            entity.Property(e => e.IntCustid).HasColumnName("intCustid");
            entity.Property(e => e.IntUpdateBy).HasColumnName("intUpdateBy");
            entity.Property(e => e.Intproductid).HasColumnName("intproductid");
            entity.Property(e => e.Intunitid).HasColumnName("intunitid");
            entity.Property(e => e.MonQty)
                .HasColumnType("money")
                .HasColumnName("monQty");
            entity.Property(e => e.Monprice)
                .HasColumnType("money")
                .HasColumnName("monprice");
            entity.Property(e => e.OrderAmount).HasColumnType("money");
            entity.Property(e => e.StrDepot)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strDepot");
            entity.Property(e => e.StrRemarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("strRemarks");
            entity.Property(e => e.Ysnactive).HasColumnName("ysnactive");
        });

        modelBuilder.Entity<TblRealtimeLocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblRealtimeLocation");

            entity.Property(e => e.DecLat)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("decLat");
            entity.Property(e => e.DecLon)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("decLon");
            entity.Property(e => e.DteGrabTime)
                .HasColumnType("datetime")
                .HasColumnName("dteGrabTime");
            entity.Property(e => e.DteInsertTime)
                .HasColumnType("datetime")
                .HasColumnName("dteInsertTime");
            entity.Property(e => e.IntEmployeeId).HasColumnName("intEmployeeID");
            entity.Property(e => e.IntNearestReatiler).HasColumnName("intNearestReatiler");
            entity.Property(e => e.StrRemarks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strRemarks");
            entity.Property(e => e.YsnActive).HasColumnName("ysnActive");
            entity.Property(e => e.YsnProcessed).HasColumnName("ysnProcessed");
        });

        modelBuilder.Entity<TblRetailer>(entity =>
        {
            entity.HasKey(e => e.IntId);

            entity.ToTable("tblRetailer");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DecLat)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("decLat");
            entity.Property(e => e.DecLon)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("decLon");
            entity.Property(e => e.InsertDate)
                .HasColumnType("datetime")
                .HasColumnName("insertDate");
            entity.Property(e => e.IntDistributor).HasColumnName("intDistributor");
            entity.Property(e => e.IntInsertBy).HasColumnName("intInsertBy");
            entity.Property(e => e.IntMarketId).HasColumnName("intMarketID");
            entity.Property(e => e.IntTerritory).HasColumnName("intTerritory");
            entity.Property(e => e.IntUnit).HasColumnName("intUnit");
            entity.Property(e => e.StrAddress)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("strAddress");
            entity.Property(e => e.StrContactNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strContactNo");
            entity.Property(e => e.StrLatLon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strLatLon");
            entity.Property(e => e.StrManager)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strManager");
            entity.Property(e => e.StrManagerContact)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strManagerContact");
            entity.Property(e => e.StrMarketName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strMarketName");
            entity.Property(e => e.StrProprietor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strProprietor");
            entity.Property(e => e.StrRetailer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strRetailer");
            entity.Property(e => e.StrType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strType");
            entity.Property(e => e.YsnActive).HasColumnName("ysnActive");
        });

        modelBuilder.Entity<TblRtmlogin>(entity =>
        {
            entity.HasKey(e => e.IntId);

            entity.ToTable("tblRTMLogin");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.DecLat)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("decLat");
            entity.Property(e => e.DecLon)
                .HasColumnType("decimal(18, 10)")
                .HasColumnName("decLon");
            entity.Property(e => e.DteExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("dteExpireDate");
            entity.Property(e => e.IntEmployeeId).HasColumnName("intEmployeeId");
            entity.Property(e => e.IntUserType).HasColumnName("intUserType");
            entity.Property(e => e.IntZone).HasColumnName("intZone");
            entity.Property(e => e.StrArea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strArea");
            entity.Property(e => e.StrDeviceId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("strDeviceId");
            entity.Property(e => e.StrMail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("strMail");
            entity.Property(e => e.StrPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strPassword");
            entity.Property(e => e.YsnActive).HasColumnName("ysnActive");
        });

        modelBuilder.Entity<TblShopSign>(entity =>
        {
            entity.HasKey(e => e.SignId);

            entity.ToTable("tblShopSign");

            entity.Property(e => e.SignId).HasColumnName("SignID");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Lat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Lon).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.ShopId).HasColumnName("ShopID");
            entity.Property(e => e.SignAddress).HasMaxLength(500);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<TblShopSignStatus>(entity =>
        {
            entity.HasKey(e => e.AutoId);

            entity.ToTable("tblShopSignStatus");

            entity.Property(e => e.AutoId).HasColumnName("AutoID");
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsUsable).HasColumnName("isUsable");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SignId).HasColumnName("SignID");
        });

        modelBuilder.Entity<TblTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblTest");

            entity.Property(e => e.StrAssetCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strAssetCode");
            entity.Property(e => e.StrDeed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("strDeed");
        });

        modelBuilder.Entity<TblZonePermission>(entity =>
        {
            entity.HasKey(e => e.IntId);

            entity.ToTable("tblZonePermission");

            entity.Property(e => e.IntId).HasColumnName("intID");
            entity.Property(e => e.IntEmployeeId).HasColumnName("intEmployeeId");
            entity.Property(e => e.IntInsertBy).HasColumnName("intInsertBy");
            entity.Property(e => e.IntLevel).HasColumnName("intLevel");
            entity.Property(e => e.IntZone).HasColumnName("intZone");
            entity.Property(e => e.YsnActive).HasColumnName("ysnActive");
        });

        modelBuilder.Entity<UserRefreshToken>(entity =>
        {
            entity.ToTable("UserRefreshToken");

            entity.HasIndex(e => e.UserId, "IX_UserRefreshToken_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.UserRefreshTokens).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
