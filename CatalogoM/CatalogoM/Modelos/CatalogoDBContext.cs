using Microsoft.EntityFrameworkCore;
namespace CatalogoM.Modelos
{
    public class CatalogoDBContext : DbContext
    {
        public CatalogoDBContext(DbContextOptions<CatalogoDBContext> options) : base(options)
        {

        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Clasificacion> Clasificaciones { get; set; }
        public DbSet<Marca> Marcas { get; set; }

    }
}
