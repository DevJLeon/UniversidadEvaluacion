namespace Dominio.Interfaces;
public interface IUnitOfWork
{
    IAsignatura Asignaturas{get;}
    ICursoEscolar CursoEscolares{get;}
    IGrado Grados{get;}
    IDepartamento Departamentos{get;}
    IPersona Personas{get;}
    Task<int> SaveAsync();

}