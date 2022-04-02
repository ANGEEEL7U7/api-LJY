using LimpiandoJuntos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LimpiandoJuntos.Infrastructure.Data
{
    public partial class LimpiandoJuntosDbContext : DbContext
    {
        public LimpiandoJuntosDbContext()
        {
        }

        public LimpiandoJuntosDbContext(DbContextOptions<LimpiandoJuntosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<Motivo> Motivo { get; set; }
        public virtual DbSet<PuntoDeInteres> PuntoDeInteres { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=BdRemota");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Denuncia_pk")
                    .IsClustered(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Notas).HasMaxLength(500);

                entity.HasOne(d => d.Motivo)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.MotivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Denuncia_Motivo_Id_fk");
            });

            modelBuilder.Entity<Motivo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Motivo_pk")
                    .IsClustered(false);

                entity.Property(e => e.MotivoDenuncia)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PuntoDeInteres>(entity =>
            {
                entity.HasKey(e => e.DenunciaId)
                    .HasName("PuntoDeInteres_pk")
                    .IsClustered(false);

                entity.Property(e => e.DenunciaId).ValueGeneratedNever();

                entity.Property(e => e.UrlFoto).HasMaxLength(100);

                entity.HasOne(d => d.Denuncia)
                    .WithOne(p => p.PuntoDeInteres)
                    .HasForeignKey<PuntoDeInteres>(d => d.DenunciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PuntoDeInteres_Denuncia_Id_fk");
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.DenunciaId)
                    .HasName("Ubicacion_pk")
                    .IsClustered(false);

                entity.Property(e => e.DenunciaId).ValueGeneratedNever();

                entity.Property(e => e.CodigoPostal).HasMaxLength(50);

                entity.Property(e => e.Colonia).HasMaxLength(150);

                entity.Property(e => e.Direccion).HasMaxLength(150);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LatLng)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Denuncia)
                    .WithOne(p => p.Ubicacion)
                    .HasForeignKey<Ubicacion>(d => d.DenunciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ubicacion_Denuncia_Id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}