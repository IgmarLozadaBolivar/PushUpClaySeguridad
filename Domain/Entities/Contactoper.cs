using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contactoper
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public int? IdPersona { get; set; }

    public int? IdTipoContacto { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; }

    public virtual Tipocontacto IdTipoContactoNavigation { get; set; }
}
