using Domain.Entities;
namespace Domain.Interfaces;

public interface IPersona : IGeneric<Persona>
{
    Task<IEnumerable<object>> ListarEmpleados();
    Task<IEnumerable<object>> ListarEmpleadosVigilantes();
    Task<IEnumerable<object>> ClientesQueVivenEnBucaramanga();
    Task<IEnumerable<object>> EmpleadosQueVivenEnGironYPiedecuesta();
}