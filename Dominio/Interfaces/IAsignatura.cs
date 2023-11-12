using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IAsignatura : IGenericRepository<Asignatura>
{
    Task<IEnumerable<object>> Consulta5();
    Task<IEnumerable<Object>> Consulta9();
    Task<IEnumerable<Object>> Consulta15();
    Task<IEnumerable<object>> Consulta30();

}