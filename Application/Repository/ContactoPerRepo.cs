using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;

public class ContactoPerRepo : Generic<ContactoPer>, IContactoPer
{
    protected readonly DbAppContext _context;

    public ContactoPerRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ContactoPer>> GetAllAsync()
    {
        return await _context.Contactopers
            //.Include(p => p.)
            .ToListAsync();
    }

    public override async Task<ContactoPer> GetByIdAsync(int id)
    {
        return await _context.Contactopers
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<ContactoPer> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Contactopers as IQueryable<ContactoPer>;
    
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search));
        }
    
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    
        return (totalRegistros, registros);
    }

    public async Task<IEnumerable<object>> ContactoEmpleadoVigilante()
    {
        var mensaje = "listado de los contactos de los empleados que son vigilantes en la empresa".ToUpper();

        var consulta = from c in _context.Contactopers
                       join emp in _context.Personas on c.IdPersona equals emp.Id
                       join e in _context.Tipopersonas on emp.IdTipoPersona equals e.Id
                       join ci in _context.Ciudads on emp.IdCiudad equals ci.Id
                       join cp in _context.Categoriapers on emp.IdCategoria equals cp.Id
                       where e.Descripcion == "Empleado" && cp.NombreCat == "Vigilante"
                       select new
                       {
                           IdEmpleado = emp.Id,
                           NombreDelEmpleado = emp.Nombre,
                           TipoDeEmpleado = e.Descripcion,
                           CategoriaDeEmpleado = cp.NombreCat,
                           DescripcionContacto = c.Descripcion,
                           TipoContacto = c.IdTipoContacto
                       };

        var resultado = await consulta.ToListAsync();

        var resultadoFinal = new List<object>
        {
            new { Msg = mensaje, DatosConsultados = resultado}
        };

        return resultadoFinal;
    }
}