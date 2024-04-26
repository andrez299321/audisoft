using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBase.Models
{
    public partial class AudisoftContext : DbContext
    {
        public AudisoftContext()
        {
        }

        public AudisoftContext(DbContextOptions<AudisoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Audisoft;MultipleActiveResultSets=True;user id=audisoftuser;password=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255);

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__Nota__idEstudian__440B1D61");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__Nota__idProfesor__4316F928");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
