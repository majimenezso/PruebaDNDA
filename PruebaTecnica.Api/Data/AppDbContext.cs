using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Models;

namespace PruebaTecnica.Api.Data
{
    // Clase que representa el contexto de la base de datos para la aplicación
    public class AppDbContext : DbContext
    {
        // Constructor que recibe las opciones de configuración para el contexto y las pasa a la clase base
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Propiedad que representa la tabla registros de login
        public DbSet<LoginLog> LoginLogs { get; set; }

        // Método para configurar el modelo y hacer ajustes adicionales durante la creación del modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            //mapea a la tabla 'login_log'
            modelBuilder.Entity<LoginLog>().ToTable("login_log");
            }
        
    }
}
