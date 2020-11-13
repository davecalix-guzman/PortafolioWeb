namespace PortafolioWebAdministracion.AppDbContext
{
    using Microsoft.EntityFrameworkCore;
    using PortafolioWebAdministracion.EntityModels;
    using PortafolioWebAdministracion.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Biografico> Biografico { get; set; }

        public DbSet<Certificacion> Certificacion { get; set; }

        public DbSet<ExperienciaLaboral> ExperienciaLaboral { get; set; }

        public DbSet<Formacion> Formacion { get; set; }

        public DbSet<Habilidad> Habilidad { get; set; }

        public DbSet<Referencia> Referencias { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
