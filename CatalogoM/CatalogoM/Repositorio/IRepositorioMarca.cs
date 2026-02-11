using CatalogoM.Modelos;
using System.Threading.Tasks;

namespace CatalogoM.Repositorio
{
    public interface IRepositorioMarca
    {
        Task<Marca?> Get(int id);
        Task<List<Marca>> GetMarcas();
        Task<Marca> Add(Marca marca);
        Task Update(int id, Marca marca);
        Task Delete(int id);
    }
}