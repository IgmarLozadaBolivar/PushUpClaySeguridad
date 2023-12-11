using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;

public class EstadoRepo : Generic<Estado>, IEstado
{
    protected readonly DbAppContext _context;
    
    public EstadoRepo(DbAppContext context) : base (context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Estado>> GetAllAsync()
    {
        return await _context.Estados
            //.Include(p => p.)
            .ToListAsync();
    }
    
    public override async Task<Estado> GetByIdAsync(int id)
    {
        return await _context.Estados
            //.Include(p => p.)
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Estado> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Estados as IQueryable<Estado>;
    
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