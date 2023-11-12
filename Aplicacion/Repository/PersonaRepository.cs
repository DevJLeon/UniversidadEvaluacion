using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    protected readonly ApiContext _context;

    public PersonaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
        .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>> Consulta1()
    {
        var dato = await _context.Personas
            .Where(p => p.Tipo == Persona.TipoPersona.alumno)
            .OrderBy(p => p.Apellido1)
            .ThenBy(P => P.Apellido2)
            .ThenBy(P => P.Nombre)
            .Select(p => new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre
            }).ToListAsync();

        return dato;
    }
    public async Task<IEnumerable<object>> Consulta2()
    {
        var dato = await (
            from p in _context.Personas
            where p.Telefono == null
            where p.Tipo == Persona.TipoPersona.alumno
            select new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre
            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta3()
    {
        var dato = await (
            from p in _context.Personas
            where p.FechaNacimiento.Year == 1999
            select new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre
            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta4()
    {
        var dato = await (
            from p in _context.Personas
            where p.Tipo == Persona.TipoPersona.profesor
            where p.Nit.ToLower().Contains("k")
            select new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre
            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta6()
    {
        var dato = await (
            from m in _context.AlumnoMatriculaAsignaturas
            join p in _context.Personas on m.AlumnoIdFk equals p.Id
            join a in _context.Asignaturas on m.AsignaturaIdFk equals a.Id
            join g in _context.Grados on a.GradoIdFk equals g.Id
            where p.Sexo == Persona.SexoPersona.M
            where g.Nombre.Contains("Grado en Ingeniería Informática (Plan 2015)")
            select new
            {
                nif = p.Nit,
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,

            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta7()
    {
        var dato = await (
            from a in _context.Asignaturas
            join g in _context.Grados on a.GradoIdFk equals g.Id
            where g.Nombre.Contains("Grado en Ingeniería Informática (Plan 2015)")
            select new
            {
                Asignatura = a.Nombre,
                curso = a.Curso,
                creditos = a.Creditos
            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta8()
    {
        var dato = await (
            from pr in _context.Profesores
            join d in _context.Departamentos on pr.DepartamentoIdFk equals d.Id
            join p in _context.Personas on pr.ProfesorIdFk equals p.Id
            where p.Tipo == Persona.TipoPersona.profesor
            select new
            {
                primerApellido = p.Apellido1,
                segundoApellido = p.Apellido2,
                nombre = p.Nombre,
                nombreDepartamento = d.Nombre
            }).Distinct()
            .OrderBy(p => p.primerApellido)
            .ThenBy(p => p.segundoApellido)
            .ThenBy(p => p.nombre)
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta10()
    {
        var dato = await (
            from a in _context.Asignaturas
            join pr in _context.Profesores on a.ProfesorIdFk equals pr.ProfesorIdFk
            join p in _context.Personas on pr.ProfesorIdFk equals p.Id
            join d in _context.Departamentos on pr.DepartamentoIdFk equals d.Id
            join g in _context.Grados on a.GradoIdFk equals g.Id
            where g.Nombre.Contains("Grado en Ingeniería Informática (Plan 2015)")
            where p.Tipo == Persona.TipoPersona.profesor
            select new
            {
                nombreDepartamento = d.Nombre
            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta11()
    {
        var dato = await (
            from m in _context.AlumnoMatriculaAsignaturas
            join p in _context.Personas on m.AlumnoIdFk equals p.Id
            join c in _context.CursoEscolares on m.CursoEscolarIdFk equals c.Id
            join a in _context.Asignaturas on m.AsignaturaIdFk equals a.Id
            where c.AnhoInicio == 2018
            where c.AnhoFin == 2019
            where p.Tipo == Persona.TipoPersona.alumno
            select new
            {
                nombre = p.Nombre,
                nif = p.Nit
            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<object> Consulta12()
    {
        var dato = await (
            from pr in _context.Profesores
            join p in _context.Personas on pr.ProfesorIdFk equals p.Id into personaGroup
            from persona in personaGroup.DefaultIfEmpty()
            join d in _context.Departamentos on pr.DepartamentoIdFk equals d.Id into departamentoGroup
            from departamento in departamentoGroup.DefaultIfEmpty()
            where persona.Tipo == Persona.TipoPersona.profesor
            orderby departamento != null ? departamento.Nombre : "Sin departamento", persona.Apellido1, persona.Apellido2, persona.Nombre
            select new
            {
                NombreDepartamento = departamento != null ? departamento.Nombre : "Sin departamento",
                PrimerApellido = persona.Apellido1,
                SegundoApellido = persona.Apellido2,
                Nombre = persona.Nombre
            })
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta13()
    {
        var dato = await (
            from persona in _context.Personas
            where persona.Tipo == Persona.TipoPersona.profesor
            where !_context.Profesores.Any(profesor => profesor.ProfesorIdFk == persona.Id)
            select new
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido1 = persona.Apellido1,
                Apellido2 = persona.Apellido2,
            })
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Consulta14()
    {
        var dato = await (
            from persona in _context.Personas
            where !_context.Asignaturas.Any(asignatura => asignatura.ProfesorIdFk == persona.Id)
            select new
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido1 = persona.Apellido1,
                Apellido2 = persona.Apellido2,
            }).ToListAsync();
        return dato;
    }

    public async Task<Object> Consulta17()
    {
        int cantAlumnas = await _context.Personas
            .Where(p => p.Tipo == Persona.TipoPersona.alumno && p.Sexo == Persona.SexoPersona.M)
            .CountAsync();

        return new
        {
            cantidadAlumnas = cantAlumnas
        };
    }

    public async Task<Object> Consulta18(int year)
    {
        int cantAlumnos = await _context.Personas
                    .Where(p => p.Tipo == Persona.TipoPersona.alumno && p.FechaNacimiento.Year == year)
                    .CountAsync();

        return new
        {
            CantidadAlumnos = cantAlumnos
        };
    }

    public async Task<IEnumerable<object>> Consulta25()
    {
        var resultado = await (
            from profesor in _context.Profesores
            join per in _context.Personas on profesor.ProfesorIdFk equals per.Id
            join asignatura in _context.Asignaturas on profesor.ProfesorIdFk equals asignatura.ProfesorIdFk into asignaturasGrupo
            let numeroAsignaturas = asignaturasGrupo.Count()
            orderby numeroAsignaturas descending
            select new
            {
                Id = profesor.ProfesorIdFk,
                Nombre = per.Nombre,
                PrimerApellido = per.Apellido1,
                SegundoApellido = per.Apellido2,
                NumeroAsignaturas = numeroAsignaturas
            }
        ).ToListAsync();

        return resultado;
    }
    public async Task<IEnumerable<object>> Consulta26()
    {
        var dato = await (
        from Persona in _context.Personas
        where Persona.Tipo == Persona.TipoPersona.alumno
        orderby Persona.FechaNacimiento descending
        select new
        {
                Id = Persona.Id,
                Nombre = Persona.Nombre,
                Apellido1 = Persona.Apellido1,
                Apellido2 = Persona.Apellido2,
                FechaNacimiento = Persona.FechaNacimiento,
                Direccion = Persona.Direccion,
        }).FirstOrDefaultAsync();
    var resultado = new List<object> { dato };

    return resultado;
    }

    public async Task<IEnumerable<object>> Consulta27()
    {
        var dato = await (
            from persona in _context.Personas
            join profesor in _context.Profesores on persona.Id equals profesor.ProfesorIdFk into profesorGroup
            where persona.Tipo == Persona.TipoPersona.profesor && !profesorGroup.Any()
            select new {
                primerApellido = persona.Apellido1,
                segundoApellido = persona.Apellido2,
                nombre = persona.Nombre,
            }
        ).ToListAsync();
        return dato;
    }

    public async Task<IEnumerable<object>> Consulta29()
    {
        var dato = await (
            from persona in _context.Personas
            join pr in _context.Profesores 
            on persona.Id equals pr.ProfesorIdFk 
            join d in _context.Departamentos 
            on pr.DepartamentoIdFk equals d.Id
            where !_context.Asignaturas.Any(asignatura => asignatura.ProfesorIdFk == persona.Id)
            select new
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido1 = persona.Apellido1,
                Apellido2 = persona.Apellido2,
                departamentoAsociado = d.Nombre,
            }).ToListAsync();
        return dato;
    }


}