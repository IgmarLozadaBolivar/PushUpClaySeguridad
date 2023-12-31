﻿namespace Domain.Entities;

public partial class DirPersona
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public int? IdPersona { get; set; }
    public int? IdTipoDireccion { get; set; }
    public virtual Persona IdPersonaNavigation { get; set; }
    public virtual TipoDireccion IdTipoDireccionNavigation { get; set; }
}