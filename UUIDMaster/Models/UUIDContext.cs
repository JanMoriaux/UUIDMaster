using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Models
{
    public class UUIDContext : DbContext
    {
        public UUIDContext(DbContextOptions<UUIDContext> options) : base(options)
        { }


        public DbSet<UserUUIDRecord> UserRecords { get; set; }
        public DbSet<EventUUIDRecord> EventRecords { get; set; }
        public DbSet<ActivityUUIDRecord> ActivityRecords { get; set; }
        public DbSet<ReservationUUIDRecord> ReservationRecords { get; set; }
        public DbSet<InvoiceUUIDRecord> InvoiceRecords { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserUUIDRecord>(entity =>
            {
                entity.ToTable("uuid_users");

                entity.Property(e => e.UUID).IsRequired().HasColumnType("varchar(36)");
                entity.Property(e => e.Email).IsRequired().HasColumnType("varchar(255)");

                entity.HasIndex(e => e.UUID).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<EventUUIDRecord>(entity =>
            {
                entity.ToTable("uuid_events");

                entity.Property(e => e.UUID).IsRequired().HasColumnType("varchar(36)");
                entity.Property(e => e.Name).IsRequired().HasColumnType("varchar(255)");

                entity.HasIndex(e => e.UUID).IsUnique();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<ActivityUUIDRecord>(entity =>
            {

                entity.ToTable("uuid_activities");

                entity.Property(e => e.UUID).IsRequired().HasColumnType("varchar(36)");
                entity.Property(e => e.Name).IsRequired().HasColumnType("varchar(255)");
                entity.Property(e => e.EventUUID).IsRequired().HasColumnType("varchar(36)");

                entity.HasIndex(e => e.UUID).IsUnique();
                entity.HasIndex(e => new { e.Name, e.EventUUID }).IsUnique();
            });

            modelBuilder.Entity<ReservationUUIDRecord>(entity =>
            {
                entity.ToTable("uuid_reservations");

                entity.Property(e => e.UUID).IsRequired().HasColumnType("varchar(36)");
                entity.Property(e => e.ActivityUUID).IsRequired().HasColumnType("varchar(36)");
                entity.Property(e => e.UserUUID).IsRequired().HasColumnType("varchar(36)");

                entity.HasIndex(e => e.UUID).IsUnique();
                entity.HasIndex(e => new { e.ActivityUUID, e.UserUUID }).IsUnique();
            });

            modelBuilder.Entity<InvoiceUUIDRecord>(entity =>
            {
                entity.ToTable("uuid_invoices");

                entity.Property(e => e.UUID).IsRequired().HasColumnType("varchar(36)");
                entity.Property(e => e.ReservationUUID).IsRequired().HasColumnType("varchar(36)");

                entity.HasIndex(e => e.UUID).IsUnique();
                entity.HasIndex(e => e.ReservationUUID).IsUnique();
            });
        }
    }
}
