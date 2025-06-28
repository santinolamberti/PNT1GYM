using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymFinal.Models
{
    public class Empleado
    {
        [Key]
        public int Legajo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Dni { get; set; }

        // Relación con sede
        [ForeignKey("Sede")]
        public int IdSede { get; set; }
        public Sede Sede { get; set; }

        // Relación con actividades (muchos a muchos)
        public ICollection<Actividad> Actividades { get; set; }
    }
}
