using Domain.Entities;
namespace Domain.Interfaces;

public interface IContactoPer : IGeneric<ContactoPer>
{
    Task<IEnumerable<object>> ContactoEmpleadoVigilante();
}