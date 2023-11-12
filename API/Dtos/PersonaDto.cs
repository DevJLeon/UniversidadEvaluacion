
namespace API.Dtos;

public class PersonaDto
{
    public enum SexoPersona
    {
        M, H
    }
    public enum TipoPersona
    {
        profesor,
        alumno
    }
    public int Id { get; set; }
    public string Nit { get; set; }
    public string Nombre { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public string Ciudad { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public SexoPersona Sexo { get; set; }
    public TipoPersona Tipo { get; set; }
}
