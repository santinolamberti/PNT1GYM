using System.ComponentModel.DataAnnotations;

namespace GymFinal.Models
{
    public class Sede
    {
        [Key]
        public int IdSede { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public ICollection<Empleado> Empleados { get; set; }

        public ICollection<Actividad> Actividades { get; set; }

        public ICollection<Socio> Socios { get; set; }
    }
}
