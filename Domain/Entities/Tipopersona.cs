namespace Domain.Entities;

public partial class TipoPersona
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}