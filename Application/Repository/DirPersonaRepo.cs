using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;

public class DirPersonaRepo : Generic<DirPersona>, IDirPersona
{
    protected readonly DbAppContext _context;

    public DirPersonaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DirPersona>> GetAllAsync()
    {
        return await _context.Dirpersonas
            //.Include(p => p.)
            .ToListAsync();
    }

    public override async Task<DirPersona> GetByIdAsync(int id)
    {
        return await _context.Dirpersonas
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<DirPersona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Dirpersonas as IQueryable<DirPersona>;
    
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Direccion.ToLower().Contains(search));
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