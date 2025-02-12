using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mis.Services.Customer.Api.Models;

public partial class MisServicesCustomerDatabaseContext : DbContext
{
    private readonly IConfiguration _iconfig;
    public MisServicesCustomerDatabaseContext()
    {
    }

   
  public MisServicesCustomerDatabaseContext(DbContextOptions<MisServicesCustomerDatabaseContext> options, IConfiguration iconfig)
        : base(options)
    {
     _iconfig = iconfig;
    }

    
    
    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_iconfig.GetConnectionString("CustomerServiceConnectionString"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.ContactPersonEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.ProjectId)
                .ValueGeneratedNever()
                .HasColumnName("ProjectID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProjectEndDate).HasColumnType("date");
            entity.Property(e => e.ProjectStartDate).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Project_Customer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
