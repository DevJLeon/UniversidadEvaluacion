
namespace Dominio.Entities;

public class Asignatura : BaseEntity
{
    public enum TipoAsignatura
    {
        obligatoria,
        optativa,
        básica
    }

    public string Nombre { get; set; }
    public float Creditos { get; set; }
    public TipoAsignatura Tipo { get; set; }
    public byte Curso { get; set; }
    public byte Cuatrimestre { get; set; }
    public int? ProfesorIdFk { get; set; }
    public Persona Persona { get; set; }
    public int GradoIdFk { get; set; }
    public Grado Grado { get; set; }

    public ICollection<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }

}
