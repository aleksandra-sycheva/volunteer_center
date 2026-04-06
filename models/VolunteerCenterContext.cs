using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace volonteer_center.models;

public partial class VolunteerCenterContext : DbContext
{
    public VolunteerCenterContext()
    {
    }

    public VolunteerCenterContext(DbContextOptions<VolunteerCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<RegistrationOfVolunteer> RegistrationOfVolunteers { get; set; }

    public virtual DbSet<RegistrationStatus> RegistrationStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=volunteer_center;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CoordinatorId).HasColumnName("coordinator_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EventName).HasColumnName("event_name");
            entity.Property(e => e.EventStatusId).HasColumnName("event_status_id");
            entity.Property(e => e.NeedVolonters).HasColumnName("need_volonters");
            entity.Property(e => e.Place).HasColumnName("place");

            entity.HasOne(d => d.Category).WithMany(p => p.Events)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_category_id_fkey");

            entity.HasOne(d => d.Coordinator).WithMany(p => p.Events)
                .HasForeignKey(d => d.CoordinatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_coordinator_id_fkey");

            entity.HasOne(d => d.EventStatus).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_event_status_id_fkey");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_statuses_pkey");

            entity.ToTable("event_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<RegistrationOfVolunteer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registration_of_volunteers_pkey");

            entity.ToTable("registration_of_volunteers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.RedistrationStatusId).HasColumnName("redistration_status_id");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.VolonteerId).HasColumnName("volonteer_id");

            entity.HasOne(d => d.Event).WithMany(p => p.RegistrationOfVolunteers)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_of_volunteers_event_id_fkey");

            entity.HasOne(d => d.RedistrationStatus).WithMany(p => p.RegistrationOfVolunteers)
                .HasForeignKey(d => d.RedistrationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_of_volunteers_redistration_status_id_fkey");

            entity.HasOne(d => d.Volonteer).WithMany(p => p.RegistrationOfVolunteers)
                .HasForeignKey(d => d.VolonteerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_of_volunteers_volonter_id_fkey");
        });

        modelBuilder.Entity<RegistrationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registration_statuses_pkey");

            entity.ToTable("registration_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.MiddleName).HasColumnName("middle_name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
