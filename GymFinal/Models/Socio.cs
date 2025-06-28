using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymFinal.Models
{
    public class Socio
    {
        [Key]
        public int IdSocio { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Dni { get; set; }

        public string Email { get; set; }

        public bool EstaActivo { get; set; }

        // Relaciones
        [ForeignKey("Plan")]
        public int IdPlan { get; set; }
        public Plan Plan { get; set; }

        [ForeignKey("Sede")]
        public int IdSede { get; set; }
        public Sede Sede { get; set; }
    }
}
