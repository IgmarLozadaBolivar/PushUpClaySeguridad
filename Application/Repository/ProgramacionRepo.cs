using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;

public class ProgramacionRepo : Generic<Programacion>, IProgramacion
{
    protected readonly DbAppContext _context;

    public ProgramacionRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Programacion>> GetAllAsync()
    {
        return await _context.Programacions
            //.Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Programacion> GetByIdAsync(int id)
    {
        return await _context.Programacions
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Programacion> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Programacions as IQueryable<Programacion>;
    
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToString().ToLower().Contains(search));
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