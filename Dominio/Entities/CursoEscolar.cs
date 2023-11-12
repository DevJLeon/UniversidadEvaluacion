
namespace Dominio.Entities;

public class CursoEscolar : BaseEntity
{
    public int AnhoInicio { get; set; }
    public int AnhoFin { get; set; }

    public ICollection<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }

}
