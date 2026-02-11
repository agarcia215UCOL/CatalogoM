using CatalogoM.Modelos;
using Microsoft.EntityFrameworkCore;
namespace CatalogoM.Repositorio
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly CatalogoDBContext _context;

        public RepositorioProductos(CatalogoDBContext context)
        {
            _context = context;
        }

        public async Task<Producto> Add(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }
        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Producto?> Get(int id)
        {
            return await _context.Productos.Include(h=>h.Marcas).Where(r=>r.Id ==id).FirstOrDefaultAsync();
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<List<Clasificacion>> GetClasificaciones()
        {
            return await _context.Clasificaciones.ToListAsync();
        }
        public async Task<List<Marca>> GetMarcas()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task Update(int id, Producto producto)
        {
            var productoactual = await _context.Productos.FindAsync(id);
            if (productoactual != null)
            {
                productoactual.Nombre = producto.Nombre;
                productoactual.Tipo = producto.Tipo;
                productoactual.Departamento = producto.Departamento;
                productoactual.Precio = producto.Precio;
                productoactual.Marcas = producto.Marcas;
                await _context.SaveChangesAsync();
            }
        }
    }
}
