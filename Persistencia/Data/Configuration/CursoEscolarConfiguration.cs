using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
    {
        public void Configure(EntityTypeBuilder<CursoEscolar> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("cursoEscolar");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.AnhoInicio)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(10);

            builder.Property(p => p.AnhoFin)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(10);

        }
    }
}