namespace Domain.Entities;

public partial class ContactoPer
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int? IdPersona { get; set; }
    public int? IdTipoContacto { get; set; }
    public virtual Persona IdPersonaNavigation { get; set; }
    public virtual TipoContacto IdTipoContactoNavigation { get; set; }
}