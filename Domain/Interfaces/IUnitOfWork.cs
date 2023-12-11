namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IUser Users { get; }
    IRol Roles { get; }

    Task<int> SaveAsync();
}