using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IDepartamento : IGenericRepository<Departamento>
{
    Task<IEnumerable<object>> Consulta16();
    Task<IEnumerable<Object>> Consulta19();
    Task<IEnumerable<Object>> Consulta20();
    Task<IEnumerable<Object>> Consulta28();
    Task<IEnumerable<Object>> Consulta31();
}