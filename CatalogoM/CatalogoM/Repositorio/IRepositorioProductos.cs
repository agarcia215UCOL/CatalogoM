using CatalogoM.Modelos;
namespace CatalogoM.Repositorio
{
    public interface IRepositorioProductos
    {
        Task<List<Producto>> GetAll();
        Task<Producto?> Get(int id);
        Task<List<Marca>> GetMarcas();
        Task<Producto> Add(Producto producto);
        Task Update(int id, Producto producto);
        Task Delete(int id);
        

    }
}
