using Domain.Entities;
namespace Domain.Interfaces;

public interface IContrato : IGeneric<Contrato>
{
    Task<IEnumerable<object>> ClientesCon5AñosDeAntiguedad();
}