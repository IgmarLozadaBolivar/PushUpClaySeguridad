namespace Domain.Entities;

public partial class Pais
{
    public int Id { get; set; }
    public string NombrePais { get; set; }
    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}