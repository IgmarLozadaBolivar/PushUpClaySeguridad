namespace API.Dtos;

public class DirPersonaDto
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public int? IdPersona { get; set; }
    public int? IdTipoDireccion { get; set; }
}