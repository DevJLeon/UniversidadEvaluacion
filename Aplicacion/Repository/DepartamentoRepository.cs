using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    protected readonly ApiContext _context;

    public DepartamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos       
        .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos      
        .FirstOrDefaultAsync(p => p.Id == id);
    }   

    public async Task<IEnumerable<object>> Consulta16()
    {
        var departamentos = await (
            from a in _context.Asignaturas
            join pe in _context.Personas on a.ProfesorIdFk equals pe.Id
            join p in _context.Profesores on pe.Id equals p.ProfesorIdFk
            join d in _context.Departamentos on p.DepartamentoIdFk equals d.Id
            select new
            {
                Departamento = d.Nombre,
                AsignaturasNoImpartidas = (
                    from a in _context.Asignaturas
                    where a.ProfesorIdFk.HasValue 
                    where !_context.AlumnoMatriculaAsignaturas.Any(m => m.AsignaturaIdFk == a.Id)
                    select a.Nombre
                ).ToList()
            })
            .Where(depto => depto.AsignaturasNoImpartidas.Any())
            .ToListAsync();
        return departamentos;
    } 

    public async Task<IEnumerable<Object>> Consulta19()
    {
        return await _context.Departamentos
                            .Where(p => p.Profesores.Count() != 0)
                            .Select(p => new
                            {
                                nombreDepartamento = p.Nombre,
                                ProfesoresAsociados = p.Profesores.Count() 
                            }).OrderByDescending(p => p.ProfesoresAsociados).ToListAsync();
    }

    public async Task<IEnumerable<Object>> Consulta20()
    {
        return await _context.Departamentos
                            .Select(p => new
                            {
                                nombreDepartamento = p.Nombre,
                                ProfesoresAsociados = p.Profesores.Count() 
                            }).OrderByDescending(p => p.ProfesoresAsociados).ToListAsync();
    }
    public async Task<IEnumerable<Object>> Consulta28()
    {
        return await _context.Departamentos
            .Where(p => p.Profesores.Count() < 1)
            .Select(p => new
            {
                idDepartamento = p.Id,
                nombreDepartamento = p.Nombre,
            }).ToListAsync();
    }

    public async Task<IEnumerable<object>> Consulta31()
    {
        var dato = await (
            from a in _context.Asignaturas
            join pe in _context.Personas on a.ProfesorIdFk equals pe.Id
            join p in _context.Profesores on pe.Id equals p.ProfesorIdFk
            join d in _context.Departamentos on p.DepartamentoIdFk equals d.Id
            select new
            {
                Departamento = d.Nombre,
                AsignaturasNoImpartidas = (
                    from a in _context.Asignaturas
                    where a.ProfesorIdFk.HasValue 
                    where !_context.AlumnoMatriculaAsignaturas.Any(m => m.AsignaturaIdFk == a.Id)
                    select a.Nombre
                ).ToList()
            })
            .Where(depto => depto.AsignaturasNoImpartidas.Any())
            .ToListAsync();
        return dato;
    }

}