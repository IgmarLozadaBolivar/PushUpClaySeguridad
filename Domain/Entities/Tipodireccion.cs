namespace Domain.Entities;

public partial class TipoDireccion
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public virtual ICollection<DirPersona> Dirpersonas { get; set; } = new List<DirPersona>();
}