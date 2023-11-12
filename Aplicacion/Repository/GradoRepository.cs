using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class GradoRepository : GenericRepository<Grado>, IGrado
{
    protected readonly ApiContext _context;

    public GradoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Grado>> GetAllAsync()
    {
        return await _context.Grados
        .ToListAsync();
    }

    public override async Task<Grado> GetByIdAsync(int id)
    {
        return await _context.Grados      
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>>Consulta21()
    {
        return await _context.Grados
                            .Select(p => new
                            {
                                Grado = p.Nombre,
                                AsignaturasAsociadas = p.Asignaturas.Where(a => p.Id == a.GradoIdFk).Count() 
                            }).OrderByDescending(p => p.AsignaturasAsociadas).ToListAsync();
    }

    public async Task<IEnumerable<Object>>Consulta22(int cantidadMinima)
    {
        return await _context.Grados
                            .Where(p => p.Asignaturas.Count() >= cantidadMinima)
                            .Select(p => new
                            {
                                Grado = p.Nombre,
                                AsignaturasAsociadas = p.Asignaturas.Where(a => p.Id == a.GradoIdFk).Count()
                            }).OrderByDescending(p => p.AsignaturasAsociadas).ToListAsync();
    }

public async Task<IEnumerable<object>> Consulta23() 
{
    return await (
        from asi in _context.Asignaturas
        join gr in _context.Grados on asi.GradoIdFk equals gr.Id
        group asi by new { gr.Nombre, asi.Tipo } into grupo
        select new
        {
            NombreGrado = grupo.Key.Nombre,
            TipoAsignatura = grupo.Key.Tipo.ToString(),
            TotalCreditos = grupo.Sum(x => x.Creditos)
        }
    )
    .OrderByDescending(x => x.TotalCreditos).ToListAsync();
}


    
}