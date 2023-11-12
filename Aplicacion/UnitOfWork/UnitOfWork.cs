using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext context;

    private CursoEscolarRepository _cursoEscolar;
    private AsignaturaRepository _asignatura;
    private GradoRepository _grado;
    private PersonaRepository _persona;
    private DepartamentoRepository _departamento;

    public UnitOfWork(ApiContext _context)
    {
        context = _context;
    }
    

    public IAsignatura Asignaturas
    {
        get
        {
            if (_asignatura == null)
            {
                _asignatura = new AsignaturaRepository(context);
            }
            return _asignatura;
        }
    }

    public ICursoEscolar CursoEscolares
    {
        get
        {
            if (_cursoEscolar == null)
            {
                _cursoEscolar = new CursoEscolarRepository(context);
            }
            return _cursoEscolar;
        }
    }

    public IGrado Grados
    {
        get
        {
            if (_grado == null)
            {
                _grado = new GradoRepository(context);
            }
            return _grado;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            if (_departamento == null)
            {
                _departamento = new DepartamentoRepository(context);
            }
            return _departamento;
        }
    }

    public IPersona Personas
    {
        get
        {
            if (_persona == null)
            {
                _persona = new PersonaRepository(context);
            }
            return _persona;
        }
    }


    public int Save()
    {
        return context.SaveChanges();
    }
    public void Dispose()
    {
        context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}