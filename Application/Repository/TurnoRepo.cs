using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;

public class TurnoRepo : Generic<Turno>, ITurno
{
    protected readonly DbAppContext _context;

    public TurnoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Turno>> GetAllAsync()
    {
        return await _context.Turnos
            //.Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Turno> GetByIdAsync(int id)
    {
        return await _context.Turnos
            //.Include(p => p.)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Turno> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Turnos as IQueryable<Turno>;
    
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreTurno.ToLower().Contains(search));
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