using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;
namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbAppContext context;
    private UserRepo _users;
    private RolRepo _roles;

    public UnitOfWork(DbAppContext _context)
    {
        context = _context;
    }


    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepo(context);
            }
            return _users;
        }
    }

    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepo(context);
            }
            return _roles;
        }
    }


    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}