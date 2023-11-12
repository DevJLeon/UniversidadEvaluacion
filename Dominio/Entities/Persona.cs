

namespace Dominio.Entities;

public class Persona : BaseEntity
{
    public enum SexoPersona
    {
        M, H
    }
    public enum TipoPersona
    {
        profesor,
        alumno
    }

    public string Nit { get; set; }
    public string Nombre { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public string Ciudad { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public SexoPersona Sexo { get; set; }
    public TipoPersona Tipo { get; set; }

    public ICollection<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }
    public ICollection<Asignatura> Asignaturas { get; set; }
    public ICollection<Profesor> Profesores { get; set; }


}

