using System;
using System.Collections.Generic;
using FinalApi.Authorized.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalApi.Authorized.Data;

public partial class MuazSecurityContext : DbContext
{
    public MuazSecurityContext()
    {
    }

    public MuazSecurityContext(DbContextOptions<MuazSecurityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.24.50.119;Initial Catalog=Muaz_Security;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserLogin");

            entity.HasIndex(e => e.IntId, "IX_UserLogin").IsUnique();

            entity.HasIndex(e => e.IntId, "IX_UserLogin_1").IsUnique();

            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.DtAccOpen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtAccOpen");
            entity.Property(e => e.IntId)
                .ValueGeneratedOnAdd()
                .HasColumnName("intID");
            entity.Property(e => e.IntRole).HasColumnName("intRole");
            entity.Property(e => e.SoftwareId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("softwareID");
            entity.Property(e => e.StrConfirmPass).HasColumnName("strConfirmPass");
            entity.Property(e => e.StrEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("strEmail");
            entity.Property(e => e.StrFirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("strFirstName");
            entity.Property(e => e.StrLastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("strLastName");
            entity.Property(e => e.StrPassword).HasColumnName("strPassword");
            entity.Property(e => e.TokenId)
                .IsUnicode(false)
                .HasColumnName("tokenID");
            entity.Property(e => e.UniqeId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("uniqeID");
            entity.Property(e => e.YsnActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ysnActive");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
