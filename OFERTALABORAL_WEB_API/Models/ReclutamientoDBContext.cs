using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OFERTALABORAL_WEB_API.Models
{
    public partial class ReclutamientoDBContext : DbContext
    {
        public ReclutamientoDBContext()
        {
        }

        public ReclutamientoDBContext(DbContextOptions<ReclutamientoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OfertaLaboral> OfertaLaboral { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-OS742RGB;Database=ReclutamientoDB;MultipleActiveResultSets=true;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<OfertaLaboral>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion");

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("empresa");

                entity.Property(e => e.FechaPublicacion).HasColumnName("fechaPublicacion");

                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lugar");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("titulo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
