
namespace Dominio.Entities;

    public class AlumnoMatriculaAsignatura
    {
        public int AlumnoIdFk{get;set;}
        public Persona Persona{get;set;}
        public int AsignaturaIdFk{get;set;}
        public Asignatura Asignatura{get;set;}
        public int CursoEscolarIdFk{get;set;}
        public CursoEscolar CursoEscolar{get;set;}
    }
