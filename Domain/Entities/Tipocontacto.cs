using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Tipocontacto
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Contactoper> Contactopers { get; set; } = new List<Contactoper>();
}
