using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;

public class TipoContactoRepo : Generic<TipoContacto>, ITipoContacto
{
    protected readonly DbAppContext _context;

    public TipoContactoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoContacto>> GetAllAsync()
    {
        return await _context.Tipocontactos
            //.Include(p => p.)
            .ToListAsync();
    }

    public override async Task<TipoContacto> GetByIdAsync(int id)
    {
        return await _context.Tipocontactos
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoContacto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Tipocontactos as IQueryable<TipoContacto>;
    
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
}