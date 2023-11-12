using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
    {
        public void Configure(EntityTypeBuilder<Asignatura> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("asignatura");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(70);

            builder.Property(p => p.Creditos)
            .IsRequired()
            .HasColumnType("float")
            .HasMaxLength(125);

            builder.Property(p => p.Curso)
            .IsRequired()
            .HasColumnType("tinyint");

            builder.Property(e => e.Tipo)
                .HasColumnName("tipo")
                .IsRequired()
                .HasMaxLength(15)
                .HasConversion<string>()
                .IsUnicode(false);
            
            builder.Property(p => p.Cuatrimestre)
            .IsRequired()
            .HasColumnType("tinyint");

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Asignaturas)
            .HasForeignKey(p => p.ProfesorIdFk);

            builder.HasOne(p => p.Grado)
            .WithMany(p => p.Asignaturas)
            .HasForeignKey(p => p.GradoIdFk);
            
            
        }
    }
}