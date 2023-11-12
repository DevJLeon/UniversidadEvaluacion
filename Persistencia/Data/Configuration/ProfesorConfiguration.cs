using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("profesor");

            builder.HasKey(e => new{e.DepartamentoIdFk,e.ProfesorIdFk});
            
            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Profesores)
            .HasForeignKey(p => p.ProfesorIdFk);

            builder.HasOne(p => p.Departamento)
            .WithMany(p => p.Profesores)
            .HasForeignKey(p => p.DepartamentoIdFk);

        }
    }
}