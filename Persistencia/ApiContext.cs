using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Asignatura> Asignaturas { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Grado> Grados { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<CursoEscolar> CursoEscolares { get; set; }
    public DbSet<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
