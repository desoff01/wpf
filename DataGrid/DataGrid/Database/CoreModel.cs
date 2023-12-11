using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace DataGrid;

public partial class CoreModel : DbContext
{
    private static CoreModel instance;
    public static CoreModel init()
    {
        if (instance == null) instance = new CoreModel();
        return instance;
    }
    public CoreModel()
    {
    }

    public CoreModel(DbContextOptions<CoreModel> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<InfoCompany> InfoCompanies { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=cfif31.ru;port=3306;userid=ISPr23-35_BarskovIA;password=ISPr23-35_BarskovIA;database=ISPr23-35_BarskovIA_Clients;characterset=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompanies).HasName("PRIMARY");

            entity.Property(e => e.IdCompanies).HasColumnName("idCompanies");
            entity.Property(e => e.Country).HasMaxLength(45);
            entity.Property(e => e.HeadOfficeCity).HasMaxLength(45);
            entity.Property(e => e.NameCompany).HasMaxLength(45);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.NumberOfContract).HasName("PRIMARY");

            entity.HasIndex(e => e.InfoCompany, "fk_Contracts_InfoCompany1_idx");

            entity.HasIndex(e => e.IdServicesService, "fk_Contracts_Services1_idx");

            entity.Property(e => e.NumberOfContract).HasColumnName("numberOfContract");
            entity.Property(e => e.IdServicesService).HasColumnName("idServicesService");

            entity.HasOne(d => d.IdServicesServiceNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdServicesService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contracts_Services1");

            entity.HasOne(d => d.InfoCompanyNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.InfoCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contracts_InfoCompany1");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.IdDirectors).HasName("PRIMARY");

            entity.Property(e => e.IdDirectors).HasColumnName("idDirectors");
            entity.Property(e => e.ContactNumber).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Family).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Patronymic).HasMaxLength(45);
        });

        modelBuilder.Entity<InfoCompany>(entity =>
        {
            entity.HasKey(e => e.IdInfoCompany).HasName("PRIMARY");

            entity.ToTable("InfoCompany");

            entity.HasIndex(e => e.Company, "fk_InfoCompany_Companies1_idx");

            entity.HasIndex(e => e.Director, "fk_InfoCompany_Directors1_idx");

            entity.Property(e => e.IdInfoCompany).HasColumnName("idInfoCompany");

            entity.HasOne(d => d.CompanyNavigation).WithMany(p => p.InfoCompanies)
                .HasForeignKey(d => d.Company)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_InfoCompany_Companies1");

            entity.HasOne(d => d.DirectorNavigation).WithMany(p => p.InfoCompanies)
                .HasForeignKey(d => d.Director)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_InfoCompany_Directors1");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdServices).HasName("PRIMARY");

            entity.Property(e => e.IdServices).HasColumnName("idServices");
            entity.Property(e => e.Service1)
                .HasMaxLength(60)
                .HasColumnName("Service");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Idlogin).HasName("PRIMARY");

            entity.Property(e => e.Idlogin).HasColumnName("idlogin");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Passwd)
                .HasMaxLength(200)
                .HasColumnName("passwd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
