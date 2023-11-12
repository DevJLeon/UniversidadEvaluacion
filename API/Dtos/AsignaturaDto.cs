using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos
{
    public class AsignaturaDto
    {
        public enum TipoAsignatura
        {
            obligatoria,
            optativa,
            básica
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Creditos { get; set; }
        public TipoAsignatura Tipo { get; set; }
        public byte Curso { get; set; }
        public byte Cuatrimestre { get; set; }
        public int? ProfesorIdFk { get; set; }
        public int GradoIdFk { get; set; }

    }
}
