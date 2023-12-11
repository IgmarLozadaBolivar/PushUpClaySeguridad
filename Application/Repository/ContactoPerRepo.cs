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
}