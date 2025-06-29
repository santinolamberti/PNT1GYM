using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace GymFinal.Models
{
        public class GimnasioContext : DbContext
        {
            public DbSet<Socio> Socios { get; set; }
            public DbSet<Plan> Planes { get; set; }
            public DbSet<Sede> Sedes { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MRM7BSP;Initial Catalog=GimnasioDB;" +
                    " Integrated Security=true; TrustServerCertificate=true; Encrypt=true");

                base.OnConfiguring(optionsBuilder);
            }
    }
}
