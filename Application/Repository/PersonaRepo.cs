using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;

public class PersonaRepo : Generic<Persona>, IPersona
{
    protected readonly DbAppContext _context;

    public PersonaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
            //.Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Persona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Personas as IQueryable<Persona>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<IEnumerable<object>> ListarEmpleados()
    {
        var mensaje = "listado de empleados de la empresa".ToUpper();

        var consulta = from c in _context.Personas
                       join e in _context.Tipopersonas on c.IdTipoPersona equals e.Id
                       join ci in _context.Ciudads on c.IdCiudad equals ci.Id
                       where e.Descripcion == "Empleado"
                       select new
                       {
                           IdEmpleado = c.Id,
                           IdUnicoPersona = c.IdPersona,
                           NombreDelEmpleado = c.Nombre,
                           TipoDeEmpleado = e.Descripcion,
                           IdCategoria = c.IdCategoria,
                           NombreCiudad = ci.NombreCiu,
                       };

        var resultado = await consulta.ToListAsync();

        var resultadoFinal = new List<object>
        {
            new { Msg = mensaje, DatosConsultados = resultado}
        };

        return resultadoFinal;
    }
}