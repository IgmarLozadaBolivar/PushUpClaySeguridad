using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Tipodireccion
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Dirpersona> Dirpersonas { get; set; } = new List<Dirpersona>();
}
