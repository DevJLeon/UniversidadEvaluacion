using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IGrado : IGenericRepository<Grado>
{
    Task<IEnumerable<Object>> Consulta21();
    Task<IEnumerable<Object>> Consulta22(int cantidadMin);
    Task<IEnumerable<object>> Consulta23();

}