namespace API.Dtos;

public class TurnoDto
{
    public int Id { get; set; }
    public string NombreTurno { get; set; }
    public TimeOnly? HoraTurnoInicio { get; set; }
    public TimeOnly? HoraTurnoFin { get; set; }
}