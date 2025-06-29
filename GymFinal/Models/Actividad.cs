using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymFinal.Models
{
    public class Actividad
    {
        [Key]
        public int CodActividad { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int DuracionMins { get; set; }

        // Relación con sede
        [ForeignKey("Sede")]
        public int IdSede { get; set; }
        public Sede Sede { get; set; }

        // Relación con empleados (muchos a muchos)
        public ICollection<Empleado> Empleados { get; set; }
    }
}
