using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
{
    protected readonly ApiContext _context;

    public AsignaturaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Asignatura>> GetAllAsync()
    {
        return await _context.Asignaturas
        .Include(p => p.Grado)
        .ToListAsync();
    }

    public override async Task<Asignatura> GetByIdAsync(int id)
    {
        return await _context.Asignaturas
        .Include(p => p.Grado)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<object>> Consulta5()
    {
        var dato = await (
            from p in _context.Asignaturas
            where p.Cuatrimestre == 1
            where p.Curso == 3
            where p.GradoIdFk == 7
            select new
            {
                Asignatura = p.Nombre,
            }).Distinct()
            .ToListAsync();

        return dato;
    }
    public async Task<IEnumerable<object>> Consulta9()
    {
        var dato = await (
            from al in _context.AlumnoMatriculaAsignaturas
            join p in _context.Personas on al.AlumnoIdFk equals p.Id
            join asg in _context.Asignaturas on al.AsignaturaIdFk equals asg.Id
            join c in _context.CursoEscolares on al.CursoEscolarIdFk equals c.Id
            where p.Tipo == Persona.TipoPersona.alumno
            where p.Nit == "26902806M"
            select new
            {
                NombreEstudiante = p.Nombre,
                Nit = p.Nit,
                NombreAsig = asg.Nombre,
                AnhoInicio = c.AnhoInicio,
                AnhoFinal = c.AnhoFin
            }).ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta15()
    {
        var dato = await (
            from asignatura in _context.Asignaturas
            where asignatura.ProfesorIdFk == null
            select new
            {
                Id = asignatura.Id,
                Nombre = asignatura.Nombre,
            }).ToListAsync();

        return dato;

    }

        public async Task<IEnumerable<object>> Consulta30()
    {
        var dato = await (
            from a in _context.Asignaturas
            where a.ProfesorIdFk == null
            orderby a.Id descending
            select new
            {
                IdAsignatura = a.Id,
                Nombre = a.Nombre,
                Creditos = a.Creditos
            })
            .ToListAsync();

        return dato;
    }
}