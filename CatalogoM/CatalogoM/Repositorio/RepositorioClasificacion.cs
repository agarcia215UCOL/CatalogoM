using CatalogoM.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CatalogoM.Repositorio
{
    public class RepositorioClasificaciones : IRepositorioClasificaciones
    {
        private readonly CatalogoDBContext _context;

        public RepositorioClasificaciones(CatalogoDBContext context)
        {
            _context = context;
        }

        public async Task<List<Clasificacion>> GetAll()
        {
            return await _context.Clasificaciones.ToListAsync();
        }

        public async Task<Clasificacion?> Get(int id)
        {
            return await _context.Clasificaciones.FindAsync(id);
        }

        public async Task<Clasificacion> Add(Clasificacion clasificacion)
        {
            _context.Clasificaciones.Add(clasificacion);
            await _context.SaveChangesAsync();
            return clasificacion;
        }

        public async Task Update(int id, Clasificacion clasificacion)
        {
            var dbClasificacion = await _context.Clasificaciones.FindAsync(id);
            if (dbClasificacion is null) return;

            dbClasificacion.Nombre = clasificacion.Nombre;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var clasificacion = await _context.Clasificaciones.FindAsync(id);
            if (clasificacion is null) return;

            _context.Clasificaciones.Remove(clasificacion);
            await _context.SaveChangesAsync();
        }
    }
}