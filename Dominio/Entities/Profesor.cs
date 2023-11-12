

namespace Dominio.Entities;

public class Profesor 
{
    public int ProfesorIdFk{get;set;}
    public Persona Persona{get;set;}
    public int DepartamentoIdFk { get; set; }
    public Departamento Departamento { get; set; }

}
