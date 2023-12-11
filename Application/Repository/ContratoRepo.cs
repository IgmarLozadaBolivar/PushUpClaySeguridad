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
}