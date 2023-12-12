using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;

public class ContratoRepo : Generic<Contrato>, IContrato
{
    protected readonly DbAppContext _context;

    public ContratoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Contrato>> GetAllAsync()
    {
        return await _context.Contratos
            //.Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Contrato> GetByIdAsync(int id)
    {
        return await _context.Contratos
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Contrato> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Contratos as IQueryable<Contrato>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.FechaContrato.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<IEnumerable<object>> ClientesCon5AñosDeAntiguedad()
    {
        var mensaje = "listado de clientes que tienen 5 años de antigüedad".ToUpper();

        var consulta = from c in _context.Contratos
                       join emp in _context.Personas on c.IdCliente equals emp.Id
                       join e in _context.Tipopersonas on emp.IdTipoPersona equals e.Id
                       where e.Descripcion == "Cliente"
                       select new
                       {
                           Contrato = c,
                           Persona = emp,
                           TipoPersona = e
                       };

        var result = await consulta.ToListAsync();

        var filteredResult = result
            .Where(ti => ti.TipoPersona.Descripcion == "Cliente" && ti.Contrato.FechaContrato.HasValue)
            .AsEnumerable()
            .Where(ti => (DateTime.Now - ti.Contrato.FechaContrato.Value.ToDateTime(TimeOnly.MinValue)).TotalDays / 365.25 >= 5)
            .Select(ti => new
            {
                IdCliente = ti.Persona.Id,
                IdUnicoPersona = ti.Persona.IdPersona,
                NombreDelCliente = ti.Persona.Nombre
            })
            .ToList();

        var resultadoFinal = new List<object>
    {
        new { Msg = mensaje, DatosConsultados = filteredResult }
    };

        return resultadoFinal;
    }

    public async Task<IEnumerable<object>> ContratosActivos()
    {
        var mensaje = "listado de contratos que se encuentran activos".ToUpper();

        var consulta = from c in _context.Contratos
                       join emp in _context.Personas on c.IdEmpleado equals emp.Id
                       join cus in _context.Personas on c.IdCliente equals cus.Id
                       join et in _context.Estados on c.IdEstado equals et.Id
                       where et.Descripcion == "Activo"
                       select new
                       {
                           NroContracto = c.Id,
                           NombreDelCliente = cus.Nombre,
                           NombreDelEmpleado = emp.Nombre
                       };

        var resultado = await consulta.ToListAsync();

        var resultadoFinal = new List<object>
        {
            new { Msg = mensaje, DatosConsultados = resultado}
        };

        return resultadoFinal;
    }
}