using Microsoft.EntityFrameworkCore;

namespace Gestion_Tareas.Models.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options): base(options) 
        { 
        }
        public DbSet<Tarea> Tareas { get; set; }
    }
}
