using System.ComponentModel.DataAnnotations;

namespace GymFinal.Models
{
    public class Plan
    {
        [Key]
        public int IdPlan { get; set; }

        [Required]
        public string NombrePlan { get; set; }

        public string DescripcionPlan { get; set; }

        [Required]
        public double Precio { get; set; }

        public ICollection<Socio> Socios { get; set; }

        //prueba 3

    }
}
