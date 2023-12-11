using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Categoriaper
{
    public int Id { get; set; }

    public string NombreCat { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
