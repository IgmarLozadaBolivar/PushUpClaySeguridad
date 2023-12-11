namespace Domain.Entities;

public partial class Departamento
{
    public int Id { get; set; }
    public string NombreDep { get; set; }
    public int? IdPais { get; set; }
    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
    public virtual Pais IdPaisNavigation { get; set; }
}