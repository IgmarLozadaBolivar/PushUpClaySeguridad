using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ciudad
{
    public int Id { get; set; }

    public string NombreCiu { get; set; }

    public int? IdDep { get; set; }

    public virtual Departamento IdDepNavigation { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
