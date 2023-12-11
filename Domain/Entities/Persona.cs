namespace Domain.Entities;

public partial class Persona
{
    public int Id { get; set; }
    public string IdPersona { get; set; }
    public string Nombre { get; set; }
    public DateOnly? DateReg { get; set; }
    public int? IdTipoPersona { get; set; }
    public int? IdCategoria { get; set; }
    public int? IdCiudad { get; set; }
    public virtual ICollection<ContactoPer> Contactopers { get; set; } = new List<ContactoPer>();
    public virtual ICollection<Contrato> ContratoIdClienteNavigations { get; set; } = new List<Contrato>();
    public virtual ICollection<Contrato> ContratoIdEmpleadoNavigations { get; set; } = new List<Contrato>();
    public virtual ICollection<DirPersona> Dirpersonas { get; set; } = new List<DirPersona>();
    public virtual CategoriaPer IdCategoriaNavigation { get; set; }
    public virtual Ciudad IdCiudadNavigation { get; set; }
    public virtual TipoPersona IdTipoPersonaNavigation { get; set; }
    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}