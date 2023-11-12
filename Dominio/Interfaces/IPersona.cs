using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPersona : IGenericRepository<Persona>
{
    Task<IEnumerable<Object>> Consulta1();
    Task<IEnumerable<Object>> Consulta2();
    Task<IEnumerable<Object>> Consulta3();
    Task<IEnumerable<Object>> Consulta4();
    Task<IEnumerable<Object>> Consulta6();
    Task<IEnumerable<Object>> Consulta7();
    Task<IEnumerable<Object>> Consulta8();
    Task<IEnumerable<Object>> Consulta10();
    Task<IEnumerable<Object>> Consulta11();
    Task<Object> Consulta12();
    Task<IEnumerable<Object>> Consulta13();
    Task<IEnumerable<Object>> Consulta14();
    Task<Object> Consulta17();
    Task<Object> Consulta18(int year);
    Task<IEnumerable<object>> Consulta25();
    Task<IEnumerable<object>> Consulta26();
    Task<IEnumerable<object>> Consulta27();
    Task<IEnumerable<object>> Consulta29();
    
}