namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IUser Users { get; }
    IRol Roles { get; }

    IPais Paises { get; }
    IDepartamento Departamentos { get; }
    ICiudad Ciudades { get; }
    IPersona Personas { get; }
    ITipoContacto TipoContactos { get; }
    ITipoDireccion TipoDirecciones { get; }
    ITipoPersona TipoPersonas { get; }
    ICategoriaPer CategoriaPers { get; }
    IContrato Contratos { get; }
    IContactoPer ContactoPers { get; }
    ITurno Turnos { get; }
    IEstado Estados { get; }
    IDirPersona DirPersonas { get; }
    IProgramacion Programacions { get; }

    Task<int> SaveAsync();
}