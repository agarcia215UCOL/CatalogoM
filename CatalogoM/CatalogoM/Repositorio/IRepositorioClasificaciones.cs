using CatalogoM.Modelos;

namespace CatalogoM.Repositorio
{
    public interface IRepositorioClasificaciones
    {
        Task<List<Clasificacion>> GetAll();
        Task<Clasificacion?> Get(int id);
        Task<Clasificacion> Add(Clasificacion clasificacion);
        Task Update(int id, Clasificacion clasificacion);
        Task Delete(int id);
    }
}