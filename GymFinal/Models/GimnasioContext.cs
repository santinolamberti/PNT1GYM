using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace GymFinal.Models
{
        public class GimnasioContext : DbContext
        {
            public DbSet<Socio> Socios { get; set; }
            public DbSet<Plan> Planes { get; set; }
            public DbSet<Sede> Sedes { get; set; }
            public DbSet<Empleado> Empleados { get; set; }
            public DbSet<Actividad> Actividades { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MRM7BSP;Initial Catalog=GimnasioDB;" +
                    " Integrated Security=true; TrustServerCertificate=true; Encrypt=true");

                base.OnConfiguring(optionsBuilder);
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación muchos-a-muchos sin cascada
            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Actividades)
                .WithMany(a => a.Empleados)
                .UsingEntity(j => j.ToTable("EmpleadoActividad"));

            // Desactivar cascada para evitar conflicto
            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Sede)
                .WithMany(s => s.Actividades)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Sede)
                .WithMany(s => s.Empleados)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
