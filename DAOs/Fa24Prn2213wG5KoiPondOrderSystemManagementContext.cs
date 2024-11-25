using System;
using System.Collections.Generic;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAOs;

public partial class Fa24Prn2213wG5KoiPondOrderSystemManagementContext : DbContext
{
    public Fa24Prn2213wG5KoiPondOrderSystemManagementContext()
    {
    }

    public Fa24Prn2213wG5KoiPondOrderSystemManagementContext(DbContextOptions<Fa24Prn2213wG5KoiPondOrderSystemManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerHistory> CustomerHistories { get; set; }

    public virtual DbSet<Design> Designs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__Customer__4D7B4ADDFC9C6437");

            entity.ToTable("CustomerHistory");

            entity.Property(e => e.HistoryId).HasColumnName("HistoryID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderStatus).HasMaxLength(20);
            entity.Property(e => e.OrderType).HasMaxLength(20);
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerHistories)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerH__Custo__4BAC3F29");
        });

        modelBuilder.Entity<Design>(entity =>
        {
            entity.HasKey(e => e.DesignId).HasName("PK__Designs__32B8E17FBE7D4587");

            entity.Property(e => e.DesignId).HasColumnName("DesignID");
            entity.Property(e => e.DesignName).HasMaxLength(100);
            entity.Property(e => e.DesignStyle).HasMaxLength(50);
            entity.Property(e => e.EstimatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ImagePath).HasMaxLength(200);
            entity.Property(e => e.PromotionId).HasColumnName("PromotionID");
            entity.Property(e => e.RecommendedUse).HasMaxLength(50);

            entity.HasOne(d => d.Promotion).WithMany(p => p.Designs)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK__Designs__Promoti__4CA06362");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF674B416B5");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ServiceOrProjectId).HasColumnName("ServiceOrProjectID");
            entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Custo__4D94879B");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF8EABEC02");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryAddress).HasMaxLength(1);
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.FinalCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus).HasMaxLength(1);
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PromotionId).HasColumnName("PromotionID");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Orders_Payments");

            entity.HasOne(d => d.Promotion).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK_Orders_Promotions");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58B7004E93");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CancellationReason).HasMaxLength(200);
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FinalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABED0B3B2788A");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ConstructionStaffId).HasColumnName("ConstructionStaffID");
            entity.Property(e => e.ConsultingStaffId).HasColumnName("ConsultingStaffID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DesignId).HasColumnName("DesignID");
            entity.Property(e => e.DesignStaffId).HasColumnName("DesignStaffID");
            entity.Property(e => e.DesignStyle).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.ProjectName).HasMaxLength(100);
            entity.Property(e => e.PromotionId).HasColumnName("PromotionID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ConsultingStaff).WithMany(p => p.ProjectConsultingStaffs)
                .HasForeignKey(d => d.ConsultingStaffId)
                .HasConstraintName("FK__Projects__Consul__5165187F");

            entity.HasOne(d => d.Customer).WithMany(p => p.ProjectCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Projects__Custom__52593CB8");

            entity.HasOne(d => d.Design).WithMany(p => p.Projects)
                .HasForeignKey(d => d.DesignId)
                .HasConstraintName("FK__Projects__Design__5441852A");

            entity.HasOne(d => d.DesignStaff).WithMany(p => p.ProjectDesignStaffs)
                .HasForeignKey(d => d.DesignStaffId)
                .HasConstraintName("FK__Projects__Design__534D60F1");

            entity.HasOne(d => d.Payment).WithMany(p => p.Projects)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__Projects__Paymen__5535A963");

            entity.HasOne(d => d.Promotion).WithMany(p => p.Projects)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK__Projects__Promot__5629CD9C");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__52C42F2FE144C631");

            entity.Property(e => e.PromotionId).HasColumnName("PromotionID");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MinOrderValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PromotionName).HasMaxLength(100);
            entity.Property(e => e.PromotionStatus).HasDefaultValue(true);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB0EADC825E0B");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Feedback).HasMaxLength(200);
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PromotionId).HasColumnName("PromotionID");
            entity.Property(e => e.Result).HasMaxLength(200);
            entity.Property(e => e.ServiceDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceStatus).HasMaxLength(20);
            entity.Property(e => e.ServiceType).HasMaxLength(50);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Services__Custom__571DF1D5");

            entity.HasOne(d => d.Payment).WithMany(p => p.Services)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__Services__Paymen__5812160E");

            entity.HasOne(d => d.Promotion).WithMany(p => p.Services)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK__Services__Promot__59063A47");

            entity.HasOne(d => d.Staff).WithMany(p => p.ServiceStaffs)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Services__StaffI__59FA5E80");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACCAD21F53");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534A0E5E382").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
