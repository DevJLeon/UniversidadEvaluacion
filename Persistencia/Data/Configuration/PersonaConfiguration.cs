using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("persona");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nit)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(9);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(p => p.Apellido1)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Apellido2)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Ciudad)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(25);

            builder.Property(p => p.Direccion)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Telefono)
            .IsRequired(false)
            .HasColumnType("varchar")
            .HasMaxLength(9);

            builder.Property(p => p.FechaNacimiento)
            .IsRequired()
            .HasColumnType("date")
            .HasMaxLength(10);

            builder.Property(e => e.Sexo)
                .HasColumnName("sexo")
                .IsRequired()
                .HasAnnotation("EnumDisplayFormat", "{0}")
                .HasMaxLength(15)
                .HasConversion<string>()
                .IsUnicode(false);

            builder.Property(e => e.Tipo)
                .HasColumnName("tipo")
                .IsRequired()
                .HasAnnotation("EnumDisplayFormat", "{0}")
                .HasMaxLength(15)
                .HasConversion<string>()
                .IsUnicode(false);
            


        }
    }
}