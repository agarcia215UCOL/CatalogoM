using CatalogoM.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CatalogoM.Repositorio
{
    public class RepositorioMarca : IRepositorioMarca
    {
        private readonly CatalogoDBContext _context;

        public RepositorioMarca(CatalogoDBContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> GetMarcas()
        {
            return await _context.Marcas
                .Select(m => new Marca { Id = m.Id, Nombre = m.Nombre })
                .ToListAsync();
        }

        public async Task<Marca?> Get(int id)
        {
            return await _context.Marcas.FindAsync(id);
        }

        public async Task<Marca> Add(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
            return marca;
        }

        public async Task Update(int id, Marca marca)
        {
            var dbMarca = await Get(id);
            if (dbMarca == null) return;

            dbMarca.Nombre = marca.Nombre;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var marca = await Get(id);
            if (marca == null) return;

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
        }
    }
}