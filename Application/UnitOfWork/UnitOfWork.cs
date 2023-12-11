using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;
namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbAppContext context;
    private UserRepo _users;
    private RolRepo _roles;
    private PaisRepo _paises;
    private DepartamentoRepo _departamentos;
    private CiudadRepo _ciudades;
    private PersonaRepo _personas;
    private TipoContactoRepo _tipoContactos;
    private TipoDireccionRepo _tipoDirecciones;
    private TipoPersonaRepo _tipoPersonas;
    private TurnoRepo _turnos;
    private ContratoRepo _contratos;
    private ContactoPerRepo _contactoPers;
    private DirPersonaRepo _dirPersonas;
    private ProgramacionRepo _programaciones;
    private EstadoRepo _estados;
    private CategoriaPerRepo _categoriaPers;

    public UnitOfWork(DbAppContext _context)
    {
        context = _context;
    }


    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepo(context);
            }
            return _users;
        }
    }

    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepo(context);
            }
            return _roles;
        }
    }
    
    public IDepartamento Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepo(context);
            }
            return _departamentos;
        }
    }

    public IPersona Personas
    {
        get
        {
            if (_personas == null)
            {
                _personas = new PersonaRepo(context);
            }
            return _personas;
        }
    }

    public ICategoriaPer CategoriaPers
    {
        get
        {
            if (_categoriaPers == null)
            {
                _categoriaPers = new CategoriaPerRepo(context);
            }
            return _categoriaPers;
        }
    }

    public IDirPersona DirPersonas
    {
        get
        {
            if (_dirPersonas == null)
            {
                _dirPersonas = new DirPersonaRepo(context);
            }
            return _dirPersonas;
        }
    }

    public ITipoContacto TipoContactos
    {
        get
        {
            if (_tipoContactos == null)
            {
                _tipoContactos = new TipoContactoRepo(context);
            }
            return _tipoContactos;
        }
    }

    public ITipoPersona TipoPersonas
    {
        get
        {
            if (_tipoPersonas == null)
            {
                _tipoPersonas = new TipoPersonaRepo(context);
            }
            return _tipoPersonas;
        }
    }

    public ITurno Turnos
    {
        get
        {
            if (_turnos == null)
            {
                _turnos = new TurnoRepo(context);
            }
            return _turnos;
        }
    }

    public IProgramacion Programacions
    {
        get
        {
            if (_programaciones == null)
            {
                _programaciones = new ProgramacionRepo(context);
            }
            return _programaciones;
        }
    }

    public IEstado Estados
    {
        get
        {
            if (_estados == null)
            {
                _estados = new EstadoRepo(context);
            }
            return _estados;
        }
    }

    public IContrato Contratos
    {
        get
        {
            if (_contratos == null)
            {
                _contratos = new ContratoRepo(context);
            }
            return _contratos;
        }
    }

    public IContactoPer ContactoPers
    {
        get
        {
            if (_contactoPers == null)
            {
                _contactoPers = new ContactoPerRepo(context);
            }
            return _contactoPers;
        }
    }

    public IPais Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepo(context);
            }
            return _paises;
        }
    }

    public ITipoDireccion TipoDirecciones
    {
        get
        {
            if (_tipoDirecciones == null)
            {
                _tipoDirecciones = new TipoDireccionRepo(context);
            }
            return _tipoDirecciones;
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepo(context);
            }
            return _ciudades;
        }
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