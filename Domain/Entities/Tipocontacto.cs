namespace Domain.Entities;

public partial class TipoContacto
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public virtual ICollection<ContactoPer> Contactopers { get; set; } = new List<ContactoPer>();
}