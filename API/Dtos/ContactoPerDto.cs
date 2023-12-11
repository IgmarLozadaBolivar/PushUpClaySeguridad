namespace API.Dtos;

public class ContactoPerDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int? IdPersona { get; set; }
    public int? IdTipoContacto { get; set; }
}