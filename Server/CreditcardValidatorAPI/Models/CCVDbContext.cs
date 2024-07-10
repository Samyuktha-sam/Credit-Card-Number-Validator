using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CreditcardValidatorAPI.Models;

namespace CreditcardValidatorAPI.Models;

public partial class CCVDbContext : DbContext
{
    public CCVDbContext()
    {
    }

    public CCVDbContext(DbContextOptions<CCVDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CardType> CardTypes { get; set; }

    public virtual DbSet<ValidationRequest> ValidationRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardType>(entity =>
        {
            entity.HasKey(e => e.CardTypeId).HasName("PK__CardType__AB0A3D3120F0F705");

            entity.Property(e => e.CardTypeId).HasColumnName("CardTypeID");
            entity.Property(e => e.CardTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prefix)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ValidationRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Validati__33A8519AF5391440");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.CardType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreditCardNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResultMsg)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
