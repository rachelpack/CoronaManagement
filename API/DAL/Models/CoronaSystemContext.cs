using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class CoronaSystemContext : DbContext
    {
        public CoronaSystemContext()
        {
        }

        public CoronaSystemContext(DbContextOptions<CoronaSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CovidInfection> CovidInfections { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CoronaSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CovidInfection>(entity =>
            {
                entity.HasKey(e => e.InfectionId)
                    .HasName("PK__CovidInf__242A69B50B673A62");

                entity.Property(e => e.InfectionId).HasColumnName("InfectionID");

                entity.Property(e => e.PositiveTestDate).HasColumnType("date");

                entity.Property(e => e.RecoveryDate).HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CovidInfections)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CovidInfe__UserI__46E78A0C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.AddressCity)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AddressStreet)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.Property(e => e.VaccinationId).HasColumnName("VaccinationID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.VaccineDate).HasColumnType("date");

                entity.Property(e => e.VaccineManufacturer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Vaccinati__UserI__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
