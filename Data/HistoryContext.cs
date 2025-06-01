using System;
using System.Collections.Generic;
using Historical__Facts_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Historical__Facts_3.Data;

public partial class HistoryContext : DbContext
{
    public HistoryContext()
    {
    }

    public HistoryContext(DbContextOptions<HistoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Africa> Africas { get; set; }

    public virtual DbSet<Antarctica> Antarcticas { get; set; }

    public virtual DbSet<Asium> Asia { get; set; }

    public virtual DbSet<Europe> Europes { get; set; }

    public virtual DbSet<NorthAmerica> NorthAmericas { get; set; }

    public virtual DbSet<Oceanium> Oceania { get; set; }

    public virtual DbSet<SouthAmerica> SouthAmericas { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Africa>(entity =>
        {
            entity.HasKey(e => e.HistoricalFactId).HasName("PK__Africa__E1C02A8860A72EB3");

            entity.ToTable("Africa");

            entity.Property(e => e.HistoricalFactId)
                .ValueGeneratedNever()
                .HasColumnName("HistoricalFactID");
        });

        modelBuilder.Entity<Antarctica>(entity =>
        {
            entity.HasKey(e => e.HistoricalFactId).HasName("PK__Antarcti__E1C02A889BB8B16F");

            entity.ToTable("Antarctica");

            entity.Property(e => e.HistoricalFactId)
                .ValueGeneratedNever()
                .HasColumnName("HistoricalFactID");
        });

        modelBuilder.Entity<Asium>(entity =>
        {
            entity.HasKey(e => e.HistoricalFactId).HasName("PK__Asia__E1C02A88332AE2C7");

            entity.Property(e => e.HistoricalFactId)
                .ValueGeneratedNever()
                .HasColumnName("HistoricalFactID");
        });

        modelBuilder.Entity<Europe>(entity =>
        {
            entity.HasKey(e => e.HistoricalFactId).HasName("PK__Europe__E1C02A88A697DCA9");

            entity.ToTable("Europe");

            entity.Property(e => e.HistoricalFactId)
                .ValueGeneratedNever()
                .HasColumnName("HistoricalFactID");
        });

        modelBuilder.Entity<NorthAmerica>(entity =>
        {
            entity.HasKey(e => e.HistoricalFactId).HasName("PK__NorthAme__E1C02A88C21AAE81");

            entity.ToTable("NorthAmerica");

            entity.Property(e => e.HistoricalFactId)
                .ValueGeneratedNever()
                .HasColumnName("HistoricalFactID");
        });

        modelBuilder.Entity<Oceanium>(entity =>
        {
            entity.HasKey(e => e.HistoricalFactId).HasName("PK__Oceania__E1C02A8875752F28");

            entity.Property(e => e.HistoricalFactId)
                .ValueGeneratedNever()
                .HasColumnName("HistoricalFactID");
        });

        modelBuilder.Entity<SouthAmerica>(entity =>
        {
            entity.HasKey(e => e.HistoricalFactId).HasName("PK__SouthAme__E1C02A8885B9B059");

            entity.ToTable("SouthAmerica");

            entity.Property(e => e.HistoricalFactId)
                .ValueGeneratedNever()
                .HasColumnName("HistoricalFactID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
