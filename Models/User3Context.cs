using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace demo2001.Models;

public partial class User3Context : DbContext
{
    public User3Context()
    {
    }

    public User3Context(DbContextOptions<User3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Judge> Judges { get; set; }

    public virtual DbSet<JudgeActivity> JudgeActivities { get; set; }

    public virtual DbSet<Moderator> Moderators { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Database = user3; Username = user3; Host = 192.168.4.102; Password = VOTfZ8PQ; Port = 5421");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Activities_pkey");

            entity.ToTable("Activities", "demo2001");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventId).HasColumnName("EventID");

            entity.HasOne(d => d.Event).WithMany(p => p.Activities)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Activities_EventID_fkey");
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Competition_pkey");

            entity.ToTable("Competition", "demo2001");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(40);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Country_pkey");

            entity.ToTable("Country", "demo2001");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.NameEng).HasMaxLength(100);
            entity.Property(e => e.NameRu).HasMaxLength(100);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Events_pkey");

            entity.ToTable("Events", "demo2001");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasMany(d => d.Participants).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "Winner",
                    r => r.HasOne<Participant>().WithMany()
                        .HasForeignKey("ParticipantId")
                        .HasConstraintName("Winners_ParticipantID_fkey"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .HasConstraintName("Winners_EventID_fkey"),
                    j =>
                    {
                        j.HasKey("EventId", "ParticipantId").HasName("Winners_pkey");
                        j.ToTable("Winners", "demo2001");
                        j.IndexerProperty<int>("EventId").HasColumnName("EventID");
                        j.IndexerProperty<int>("ParticipantId").HasColumnName("ParticipantID");
                    });
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Gender_pkey");

            entity.ToTable("Gender", "demo2001");

            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(7);
        });

        modelBuilder.Entity<Judge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Judges_pkey");

            entity.ToTable("Judges", "demo2001");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Pasword).HasMaxLength(7);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Photo).HasMaxLength(10);

            entity.HasOne(d => d.CompetitionNavigation).WithMany(p => p.Judges)
                .HasForeignKey(d => d.Competition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Judges_Competition_fkey");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Judges)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("Judges_Country_fkey");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Judges)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Judges_Gender_fkey");
        });

        modelBuilder.Entity<JudgeActivity>(entity =>
        {
            entity.HasKey(e => new { e.JudgeId, e.ActivityId, e.ParticipantId }).HasName("JudgeActivity_pkey");

            entity.ToTable("JudgeActivity", "demo2001");

            entity.Property(e => e.JudgeId).HasColumnName("JudgeID");
            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");

            entity.HasOne(d => d.Activity).WithMany(p => p.JudgeActivities)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("JudgeActivity_ActivityID_fkey");

            entity.HasOne(d => d.Judge).WithMany(p => p.JudgeActivities)
                .HasForeignKey(d => d.JudgeId)
                .HasConstraintName("JudgeActivity_JudgeID_fkey");

            entity.HasOne(d => d.Participant).WithMany(p => p.JudgeActivities)
                .HasForeignKey(d => d.ParticipantId)
                .HasConstraintName("JudgeActivity_ParticipantID_fkey");
        });

        modelBuilder.Entity<Moderator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Moderators_pkey");

            entity.ToTable("Moderators", "demo2001");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Pasword).HasMaxLength(20);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Photo).HasMaxLength(10);

            entity.HasOne(d => d.CompetitionNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Competition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Moderators_Competition_fkey");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("Moderators_Country_fkey");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Moderators_Gender_fkey");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Organizers_pkey");

            entity.ToTable("Organizers", "demo2001");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Pasword).HasMaxLength(15);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Photo).HasMaxLength(10);

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("Organizers_Country_fkey");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Organizers_Gender_fkey");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Participants_pkey");

            entity.ToTable("Participants", "demo2001");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Pasword).HasMaxLength(20);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Photo).HasMaxLength(10);

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Participants)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("Participants_Country_fkey");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Participants)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Participants_Gender_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
