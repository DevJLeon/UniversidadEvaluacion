using Dominio.Entities;

namespace Dominio.Interfaces;

public interface ICursoEscolar : IGenericRepository<CursoEscolar>
{
    Task<Object> Consulta24();
}