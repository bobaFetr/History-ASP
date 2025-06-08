using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Historical__Facts_3.Models;

public partial class History2Context : DbContext
{
    public History2Context()
    {
    }

    public History2Context(DbContextOptions<History2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventPerson> EventPeople { get; set; }

    public virtual DbSet<Events2> Events2s { get; set; }

    public virtual DbSet<EventsAlt> EventsAlts { get; set; }

    public virtual DbSet<Fact> Facts { get; set; }

    public virtual DbSet<FactsOld> FactsOlds { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HISTORY2;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Continent>(entity =>
        {
            entity.HasKey(e => e.ContinentId).HasName("PK__Continen__7E5220817A20B779");

            entity.Property(e => e.ContinentId)
                .ValueGeneratedNever()
                .HasColumnName("ContinentID");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Continen__E521BB3692DF738B");

            entity.Property(e => e.EventId)
                .ValueGeneratedNever()
                .HasColumnName("EventID");
        });

        modelBuilder.Entity<EventPerson>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Event_Person");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
        });

        modelBuilder.Entity<Events2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("events2");

            entity.Property(e => e.EventId).HasColumnName("EventID");
        });

        modelBuilder.Entity<EventsAlt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("events_alt");

            entity.Property(e => e.EventId).HasColumnName("EventID");
        });

        modelBuilder.Entity<Fact>(entity =>
        {
            entity.HasKey(e => e.FactId).HasName("PK__Facts__74D3209DD3016603");

            entity.Property(e => e.FactId)
                .ValueGeneratedNever()
                .HasColumnName("FactID");
            entity.Property(e => e.ContinentId).HasColumnName("ContinentID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
        });

        modelBuilder.Entity<FactsOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("facts_old");

            entity.Property(e => e.ContinentId).HasColumnName("ContinentID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.FactId).HasColumnName("FactID");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__PHOTOS__21B7B582C60E47F6");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            entity.Property(e => e.Descr).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
