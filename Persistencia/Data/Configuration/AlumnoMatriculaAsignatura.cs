using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class AlumnoMatriculaAsignaturaConfiguration : IEntityTypeConfiguration<AlumnoMatriculaAsignatura>
    {
        public void Configure(EntityTypeBuilder<AlumnoMatriculaAsignatura> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("alumnoMatriculaAsignatura");

            builder.HasKey(e => new {e.AlumnoIdFk,e.AsignaturaIdFk,e.CursoEscolarIdFk});

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.AlumnoMatriculaAsignaturas)
            .HasForeignKey(p => p.AlumnoIdFk);

            builder.HasOne(p => p.Asignatura)
            .WithMany(p => p.AlumnoMatriculaAsignaturas)
            .HasForeignKey(p => p.AsignaturaIdFk);

            builder.HasOne(p => p.CursoEscolar)
            .WithMany(p => p.AlumnoMatriculaAsignaturas)
            .HasForeignKey(p => p.CursoEscolarIdFk);
        }
    }
}